namespace Unitagram.Application.Exceptions;

public class InvalidAccountCredentialsException : Exception
{
    public InvalidAccountCredentialsException(string message) : base(message)
    {
        
    }
}