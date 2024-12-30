using LavanderTyperWeb.Core.Data;
using LavanderTyperWeb.Domain.Primitives.Common.Interfaces.Repositories;
using LavanderTyperWeb.Domain.Primitives.Entities.Loggers;
using LavanderTyperWeb.Domain.Primitives.Entities.Loggers.Enums;
using LavanderTyperWeb.Infrastructure.Loggers.Interfaces;
using Newtonsoft.Json;

namespace LavanderTyperWeb.Infrastructure.Loggers.Models
{
    public class LoggerService : ILoggerService
    {
        private readonly ILoggerRepository _logRepository;
        private readonly IUnitOfWork _unitOfWork;
        private string _correlationalId;

        public LoggerService(
            ILoggerRepository logRepository,
            IUnitOfWork unitOfWork)
        {
            _logRepository = logRepository;
            _unitOfWork = unitOfWork;
            _correlationalId = string.Empty;
        }

#pragma warning disable CS8604 // Possible null reference argument.
        public async Task LogInfoAsync(
            object? payload,
            string message,
            string method,
            object? response = null)
        {
            var correlationalId = _correlationalId;
            await LogAsync(
                LogType.Info,
                message,
                method,
                correlationalId,
                payload,
                response);
        }
#pragma warning restore CS8604 // Possible null reference argument.

        public async Task LogWarningAsync(
            object payload,
            string message,
            string method)
        {
            var correlationalId = _correlationalId;
            await LogAsync(
                LogType.Warning,
                message,
                method,
                correlationalId,
                payload);
        }

        public async Task LogErrorAsync(
            Exception exception,
            object payload,
            string message,
            string method)
        {
            var correlationalId = _correlationalId;
            var errorMessage = $"{message}: {exception.Message}";
            await LogAsync(
                LogType.Error,
                errorMessage,
                method,
                correlationalId,
                payload);
        }

        private async Task LogAsync(
            LogType type,
            string message,
            string method,
            string correlationalId,
            object payload,
            object? response = null)
        {
            var log = new Logger
            {
                Type = type,
                Message = message,
                Source = "LavanderTyperApi",
                Method = method,
                CorrelationalId = correlationalId,
                Payload = payload != null ? ConvertObjectToJson(payload) : string.Empty,
                Response = response != null ? ConvertObjectToJson(response) : string.Empty,
            };

            await _logRepository.Create(log);
            await _unitOfWork.CommitChangesAsync();
        }

        public void SetCorrelationalId(string correlationalId) => _correlationalId = correlationalId;

        private string ConvertObjectToJson(object obj) => JsonConvert.SerializeObject(obj);
    }
}