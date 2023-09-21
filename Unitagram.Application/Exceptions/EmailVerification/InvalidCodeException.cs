namespace Unitagram.Application.Exceptions.EmailVerification;

public class InvalidCodeException : Exception
{
    public InvalidCodeException(string message) : base(message)
    {
        
    }
    
    public InvalidCodeException()
    {
        
    }
}