using LavanderTyperWeb.Domain.Primitives.Entities.Incidents;
using LavanderTyperWeb.Tests.Domain.Scenarios.Incidents;

namespace LavanderTyperWeb.Tests.Domain.Primitives.Entities.Incidents
{
    public class IncidentTests
    {
        [Theory]
        [MemberData(nameof(IncidentScenarios.GetScenarios), MemberType = typeof(IncidentScenarios))]
        public void TestIncidentValidation(IncidentScenario scenario)
        {
            //Arrange
            var incident = scenario.ToIncident();

            //Act
            bool isValid = ValidateIncident(incident);

            //Assert
            Assert.Equal(scenario.ExpectedIsValid, isValid);
        }

        private bool ValidateIncident(Incident incident)
        {
            if (incident.IdBranch == Guid.Empty ||
                incident.IdEmployee == Guid.Empty ||
                string.IsNullOrWhiteSpace(incident.Description) ||
                incident.Branch == null ||
                incident.Employee == null)
            {
                return false;
            }

            return true;
        }
    }
}