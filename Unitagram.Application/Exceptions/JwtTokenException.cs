namespace Unitagram.Application.Exceptions;

public class JwtTokenException : Exception
{
    public JwtTokenException(string message) : base(message)
    {
        
    }
    
    public JwtTokenException()
    {
        
    }
}