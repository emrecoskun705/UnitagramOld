namespace Unitagram.Application.Exceptions;

public class EmailAlreadyConfirmedException : Exception
{
    public EmailAlreadyConfirmedException(string message) : base(message)
    {
        
    }
    
    public EmailAlreadyConfirmedException()
    {
        
    }
}