using System.Security.Cryptography;
using LanguageExt;
using LanguageExt.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Unitagram.Application.Contracts.Email;
using Unitagram.Application.Contracts.Identity;
using Unitagram.Application.Contracts.Persistence;
using Unitagram.Application.Exceptions;
using Unitagram.Application.Models.Email;
using Unitagram.Application.Models.Identity.OTP;
using Unitagram.Domain;
using Unitagram.Identity.Models;

namespace Unitagram.Identity.Services;

public class EmailVerificationService : IEmailVerificationService
{
    private readonly IOtpConfirmationRepository _otpConfirmationRepository;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IEmailSender _emailSender;
    private readonly EmailOtpSettings _emailOtpSettings;


    public EmailVerificationService(
        IOtpConfirmationRepository otpConfirmationRepository,
        UserManager<ApplicationUser> userManager, 
        IEmailSender emailSender,
        IOptions<EmailOtpSettings> emailOtpSettings)
    {
        _otpConfirmationRepository = otpConfirmationRepository;
        _userManager = userManager;
        _emailSender = emailSender;
        _emailOtpSettings = emailOtpSettings.Value;
    }

    public async Task<Result<Unit>> GenerateAsync(Guid userId)
    {
        var purpose = _emailOtpSettings.Name;
        
        var otpConfirmation = await _otpConfirmationRepository.GetByUserIdAndName(userId, purpose);

        if (otpConfirmation is null)
        {
            var token = GenerateRandom6DigitCode();

            await CreateOtpConfirmation(userId, purpose, token);

            var user = await _userManager.FindByIdAsync(userId.ToString());

            await _emailSender.SendEmail(ConfirmationEmailTemplate.ToEmailMessage(user!.Email!, token), isBodyHtml: true);
            
            return Unit.Default;
        }
        
        if (IsRetryTimeElapsed(otpConfirmation))
        {
            var token = GenerateRandom6DigitCode();
            
            await UpdateOtpConfirmation(userId, purpose, token);
            
            var user = await _userManager.FindByIdAsync(userId.ToString());
            
            await _emailSender.SendEmail(ConfirmationEmailTemplate.ToEmailMessage(user!.Email!, token), isBodyHtml: true);
            return Unit.Default;
        }

        var minutesDifference = CalculateMinutesDifference(otpConfirmation.RetryDateTimeUtc!.Value);
        var exception = new BadRequestException($"Please try again after {minutesDifference} minutes later");
        return new Result<Unit>(exception);
    }

    public async Task<Result<bool>> ValidateAsync(Guid userId, string token)
    {
        var purpose = _emailOtpSettings.Name;
        var maxRetryCount = _emailOtpSettings.RetryCount;
        
        // get token using purpose
        var otpConfirmation = await _otpConfirmationRepository.GetByUserIdAndName(userId, purpose);        
        
        if (otpConfirmation is null || IsRetryTimeElapsed(otpConfirmation))
        {
            var exception = new BadRequestException("Please create new confirmation code");
            return new Result<bool>(exception);
        }
        
        // check max retry count is passed
        if (otpConfirmation.RetryCount > maxRetryCount)
        {
            var exception = new BadRequestException("You've exceeded the maximum code usage");
            return new Result<bool>(exception);
        }        
        
        // if invalid token then increment maxRetryCount
        if (token != otpConfirmation.Value)
        {
            otpConfirmation.RetryCount++;
            await _otpConfirmationRepository.UpdateAsync(otpConfirmation);
            var exception = new BadRequestException("Invalid code");
            return new Result<bool>(exception);
        }
        
        // if code reaches this part everything is ok and email can be confirmed
        
        // confirm email
        var user = await _userManager.FindByIdAsync(userId.ToString());
        user!.EmailConfirmed = true;
        await _userManager.UpdateAsync(user);
        
        // remove otpConfirmation
        await _otpConfirmationRepository.DeleteAsync(otpConfirmation);
        
        return true;
    }
    
    private string GenerateRandom6DigitCode()
    {
        using var rng = RandomNumberGenerator.Create();
        var bytes = new byte[4]; // Dört bayt uzunluğunda bir dizi oluşturuyoruz.
        rng.GetBytes(bytes); // Rastgele baytları dolduruyoruz.
        int code = BitConverter.ToInt32(bytes, 0) % 1000000; // 6 haneli bir sayı üretiyoruz.
        if (code < 0) code *= -1; // Negatif bir sayıyı pozitife çeviriyoruz.
        return code.ToString("D6"); // Format as a 6-digit string
    }
    private bool IsRetryTimeElapsed(OtpConfirmation otpConfirmation)
    {
        var now = DateTimeOffset.UtcNow;
        return (otpConfirmation.RetryDateTimeUtc.HasValue && now >= otpConfirmation.RetryDateTimeUtc.Value);
    }

    private double CalculateMinutesDifference(DateTimeOffset retryDateTime)
    {
        var now = DateTimeOffset.UtcNow;
        var timeDifference = retryDateTime - now;
        return timeDifference.TotalMinutes + 1;
    }

    private async Task CreateOtpConfirmation(Guid userId, string purpose, string token)
    {
        var retryDateTime = DateTimeOffset.Now.AddMinutes(15);
        var otpConfirmation = new OtpConfirmation()
        {
            UserId = userId,
            Name = purpose,
            RetryDateTimeUtc = retryDateTime,
            RetryCount = 0,
            Value = token,
        };

        await _otpConfirmationRepository.CreateAsync(otpConfirmation);
    }
    
    private async Task UpdateOtpConfirmation(Guid userId, string purpose, string token)
    {
        var retryDateTime = DateTimeOffset.Now.AddMinutes(15);
        var otpConfirmation = new OtpConfirmation()
        {
            UserId = userId,
            Name = purpose,
            RetryDateTimeUtc = retryDateTime,
            RetryCount = 0,
            Value = token,
        };

        await _otpConfirmationRepository.UpdateAsync(otpConfirmation);
    }
    

}