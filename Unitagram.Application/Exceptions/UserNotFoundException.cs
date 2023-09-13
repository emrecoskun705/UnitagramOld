namespace Unitagram.Application.Exceptions;

public class UserNotFoundException : Exception
{
    public UserNotFoundException() : base("User not found")
    {
        
    }
    
    public UserNotFoundException(string value) : base($"User ({value}) was not found")
    {
            
    }
}