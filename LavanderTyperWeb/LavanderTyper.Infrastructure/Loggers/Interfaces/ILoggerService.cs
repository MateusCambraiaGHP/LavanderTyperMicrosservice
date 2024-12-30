namespace LavanderTyperWeb.Infrastructure.Loggers.Interfaces
{
    public interface ILoggerService
    {
        Task LogInfoAsync(
            object? payload,
            string message,
            string method,
            object? response = null);
        Task LogWarningAsync(
            object payload,
            string message,
            string method);
        Task LogErrorAsync(
            Exception exception,
            object payload,
            string message,
            string method);

        void SetCorrelationalId(string correlationalId);
    }
}
