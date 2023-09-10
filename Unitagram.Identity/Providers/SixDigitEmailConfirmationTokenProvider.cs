using System.Security.Cryptography;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Unitagram.Identity.Providers;

public class SixDigitEmailConfirmationTokenProvider<TUser> : DataProtectorTokenProvider<TUser> where TUser : class
{
    public SixDigitEmailConfirmationTokenProvider(IDataProtectionProvider dataProtectionProvider, 
        IOptions<SixDigitEmailConfirmationTokenProviderOptions> options, 
        ILogger<DataProtectorTokenProvider<TUser>> logger) 
        : base(dataProtectionProvider, options, logger)
    {
    }    
    
    public class SixDigitEmailConfirmationTokenProviderOptions : DataProtectionTokenProviderOptions
    {
        
    }

    public override Task<string> GenerateAsync(string purpose, UserManager<TUser> manager, TUser user)
    {
        if (manager == null)
        {
            throw new ArgumentNullException(nameof(manager));
        }
        
        var code = GenerateRandom6DigitCode(); // Generate a 6-digit code as a string
        return Task.FromResult(code);
    }

    private string GenerateRandom6DigitCode()
    {
        var token = new byte[3];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(token);
        var code = BitConverter.ToUInt32(token, 0) % 1000000; // Generate a 6-digit code
        return code.ToString("D6"); // Format as a 6-digit string
    }
}