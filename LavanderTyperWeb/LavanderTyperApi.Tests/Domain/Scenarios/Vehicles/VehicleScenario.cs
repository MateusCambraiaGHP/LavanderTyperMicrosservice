using LavanderTyperWeb.Domain.Primitives.Entities.Branchs;
using LavanderTyperWeb.Domain.Primitives.Entities.Employees;
using LavanderTyperWeb.Domain.Primitives.Entities.Vehicles;
using LavanderTyperWeb.Domain.Primitives.Entities.Vehicles.Enums;
using LavanderTyperWeb.Domain.Primitives.Entities.Vehicles.ValueObjects;
using LavanderTyperWeb.Tests.Domain.Scenarios.Common;

namespace LavanderTyperWeb.Tests.Domain.Scenarios.Vehicles
{
    public class VehicleScenario : Scenario
    {
        public Guid IdBranch { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string LicensePlate { get; set; }
        public VehicleCondition? VehicleCondition { get; set; }
        public double? Price { get; set; }
        public List<Gas> Gas { get; set; }
        public List<Employee> Employees { get; set; }
        public Branch Branch { get; set; }
        public bool ExpectedIsValid { get; set; }

        public Vehicle ToVehicle()
        {
            return new Vehicle(
                IdBranch,
                Name,
                Description,
                LicensePlate,
                VehicleCondition,
                Price,
                Gas,
                Employees,
                Branch);
        }
    }
}
