using LavanderTyperWeb.Core.DomainObjects;
using LavanderTyperWeb.Domain.Primitives.Entities.Loggers.Enums;

namespace LavanderTyperWeb.Domain.Primitives.Entities.Loggers
{
    public class Logger : EntityBase
    {
        public string CorrelationalId { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public string Source { get; set; } = string.Empty;
        public string Method { get; set; } = string.Empty;
        public string Payload { get; set; } = string.Empty;
        public string Response { get; set; } = string.Empty;
        public LogType Type { get; set; }

        public Logger() { }
    }
}
