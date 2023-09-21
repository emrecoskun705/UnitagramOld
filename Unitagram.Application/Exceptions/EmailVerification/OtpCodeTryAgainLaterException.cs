using System.Globalization;

namespace Unitagram.Application.Exceptions.EmailVerification;

public class OtpCodeTryAgainLaterException : Exception
{
    public OtpCodeTryAgainLaterException(string message) : base(message)
    {
        
    }
    
    public OtpCodeTryAgainLaterException()
    {
        
    }
}