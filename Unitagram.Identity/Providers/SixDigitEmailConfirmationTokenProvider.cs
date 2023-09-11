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

    private string GenerateRandom6DigitCode()
    {
        var token = new byte[3];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(token);
        var code = BitConverter.ToUInt32(token, 0) % 1000000; // Generate a 6-digit code
        return code.ToString("D6"); // Format as a 6-digit string
    }
}