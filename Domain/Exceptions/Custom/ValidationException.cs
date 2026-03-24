namespace Domain.Exceptions.Custom;

public sealed class ValidationException : DomainExceptionBase
{
    public ValidationException(string message) : base(message)
    {
    }
    public ValidationException(string message, Exception? innerException) : base(message, innerException)
    {
    }
}
