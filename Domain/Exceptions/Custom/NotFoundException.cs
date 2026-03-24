namespace Domain.Exceptions.Custom;

public sealed class NotFoundException : DomainExceptionBase
{
    public NotFoundException(string message) : base(message)
    {
    }
    public NotFoundException(string message, Exception? innerException) : base(message, innerException)
    {
    }
}
