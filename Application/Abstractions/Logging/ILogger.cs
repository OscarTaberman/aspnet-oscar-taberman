namespace Application.Abstractions.Logging;

public interface ILogger
{
    void Log(string message);
    void Log(Exception exception);
}
