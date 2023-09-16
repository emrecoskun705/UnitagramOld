namespace Unitagram.Application.Exceptions;

public class EmailAlreadyConfirmedException : Exception
{
    public EmailAlreadyConfirmedException() : base("Email is already confirmed.")
    {
        
    }
}