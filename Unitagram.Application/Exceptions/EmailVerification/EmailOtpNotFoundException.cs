namespace Unitagram.Application.Exceptions.EmailVerification;

public class EmailOtpNotFoundException : Exception
{
    public EmailOtpNotFoundException(string message) : base(message)
    {
        
    }
    
    public EmailOtpNotFoundException()
    {
        
    }
}