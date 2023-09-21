namespace Unitagram.Application.Exceptions.EmailVerification;

public class ReachedMaximumCodeUsageException : Exception
{
    public ReachedMaximumCodeUsageException(string message) : base(message)
    {
        
    }
    
    public ReachedMaximumCodeUsageException()
    {
        
    }
}