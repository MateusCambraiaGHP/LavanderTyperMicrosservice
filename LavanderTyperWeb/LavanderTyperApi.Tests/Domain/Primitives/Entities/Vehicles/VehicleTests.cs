using LavanderTyperWeb.Domain.Primitives.Entities.Vehicles;
using LavanderTyperWeb.Tests.Domain.Scenarios.Vehicles;

namespace LavanderTyperWeb.Tests.Domain.Primitives.Entities.Vehicles
{
    public class VehicleTests
    {
        [Theory]
        [MemberData(nameof(VehicleScenarios.GetScenarios), MemberType = typeof(VehicleScenarios))]
        public void TestVehicleValidation(VehicleScenario scenario)
        {
            //Arrange
            var vehicle = scenario.ToVehicle();

            //Act
            bool isValid = ValidateVehicle(vehicle);

            //Assert
            Assert.Equal(scenario.ExpectedIsValid, isValid);
        }

        private bool ValidateVehicle(Vehicle vehicle)
        {
            if (vehicle.IdBranch == Guid.Empty ||
                string.IsNullOrWhiteSpace(vehicle.LicensePlate) ||
                vehicle.Branch == null)
            {
                return false;
            }

            return true;
        }
    }
}