namespace Domain.Exceptions.Custom;

public sealed class ConflictException : DomainExceptionBase
{
    public ConflictException(string message) : base(message)
    {
    }
    public ConflictException(string message, Exception? innerException) : base(message, innerException)
    {
    }
}
