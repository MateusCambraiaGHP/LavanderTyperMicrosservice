using LavanderTyperWeb.Domain.Primitives.Entities.Loggers;
using LavanderTyperWeb.Domain.Primitives.Entities.Loggers.Enums;
using LavanderTyperWeb.Tests.Domain.Scenarios.Common;

namespace LavanderTyperWeb.Tests.Domain.Scenarios.Loggers
{
    public class LoggerScenario : Scenario
    {
        public string CorrelationalId { get; set; }
        public string Message { get; set; }
        public string Source { get; set; }
        public string Method { get; set; }
        public string Payload { get; set; }
        public string Response { get; set; }
        public LogType Type { get; set; }
        public bool ExpectedIsValid { get; set; }

        public Logger ToLogger()
        {
            return new Logger
            {
                CorrelationalId = CorrelationalId,
                Message = Message,
                Source = Source,
                Method = Method,
                Payload = Payload,
                Response = Response,
                Type = Type
            };
        }
    }


}
