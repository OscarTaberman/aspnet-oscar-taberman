namespace Domain.Exceptions.Custom;

public sealed class NullException : DomainExceptionBase
{
    public NullException(string message) : base(message)
    {
    }
    public NullException(string message, Exception? innerException) : base(message, innerException)
    {
    }
}
