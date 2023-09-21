namespace Unitagram.Application.Exceptions;

public class AccountLockoutException : Exception
{
    public AccountLockoutException(string message) : base(message)
    {
        
    }
    
    public AccountLockoutException()
    {
        
    }
}