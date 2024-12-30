using LavanderTyperWeb.Domain.Primitives.Entities.Loggers.Enums;

namespace LavanderTyperWeb.Tests.Domain.Scenarios.Loggers
{
    public static class LoggerScenarios
    {
        public static IEnumerable<object[]> GetScenarios()
        {
            yield return new object[]
            {
                new LoggerScenario
                {
                    CorrelationalId = Guid.NewGuid().ToString(),
                    Message = "Request succeeded.",
                    Source = "API Gateway",
                    Method = "POST",
                    Payload = "{\"id\":1,\"value\":\"test\"}",
                    Response = "{\"status\":\"ok\"}",
                    Type = LogType.Info,
                    ExpectedIsValid = true
                }
            };

            yield return new object[]
            {
                new LoggerScenario
                {
                    CorrelationalId = Guid.NewGuid().ToString(),
                    Message = "Null reference exception.",
                    Source = "User Service",
                    Method = "GET",
                    Payload = "",
                    Response = "500 Internal Server Error",
                    Type = LogType.Error,
                    ExpectedIsValid = true
                }
            };

            yield return new object[]
            {
                new LoggerScenario
                {
                    CorrelationalId = "",
                    Message = "",
                    Source = "Order Service",
                    Method = "PUT",
                    Payload = "{\"orderId\":10}",
                    Response = "{\"status\":\"failed\"}",
                    Type = LogType.Warning,
                    ExpectedIsValid = false
                }
            };
        }
    }

}
