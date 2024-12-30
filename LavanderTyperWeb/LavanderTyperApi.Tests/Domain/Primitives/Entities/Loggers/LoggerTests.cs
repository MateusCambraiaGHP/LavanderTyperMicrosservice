using LavanderTyperWeb.Domain.Primitives.Entities.Loggers;
using LavanderTyperWeb.Tests.Domain.Scenarios.Loggers;

namespace LavanderTyperWeb.Tests.Domain.Primitives.Entities.Loggers
{
    public class LoggerTests
    {
        [Theory]
        [MemberData(nameof(LoggerScenarios.GetScenarios), MemberType = typeof(LoggerScenarios))]
        public void TestLoggerValidation(LoggerScenario scenario)
        {
            //Arrange
            var logger = scenario.ToLogger();

            //Act
            bool isValid = ValidateLogger(logger);

            //Assert
            Assert.Equal(scenario.ExpectedIsValid, isValid);
        }

        private bool ValidateLogger(Logger logger)
        {
            if (string.IsNullOrWhiteSpace(logger.CorrelationalId) ||
                string.IsNullOrWhiteSpace(logger.Message) ||
                string.IsNullOrWhiteSpace(logger.Source) ||
                string.IsNullOrWhiteSpace(logger.Method))
            {
                return false;
            }

            return true;
        }
    }
}