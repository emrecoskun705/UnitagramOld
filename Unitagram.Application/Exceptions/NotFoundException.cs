namespace Unitagram.Application.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException(string name) : base(name)
    {
            
    }
}