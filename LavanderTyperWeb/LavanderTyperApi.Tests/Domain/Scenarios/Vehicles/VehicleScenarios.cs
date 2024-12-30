using LavanderTyperWeb.Domain.Primitives.Entities.Branchs;
using LavanderTyperWeb.Domain.Primitives.Entities.Companies;
using LavanderTyperWeb.Domain.Primitives.Entities.Employees;
using LavanderTyperWeb.Domain.Primitives.Entities.Vehicles.Enums;
using LavanderTyperWeb.Domain.Primitives.Entities.Vehicles.ValueObjects;

namespace LavanderTyperWeb.Tests.Domain.Scenarios.Vehicles
{
    public static class VehicleScenarios
    {
        public static IEnumerable<object[]> GetScenarios()
        {
            yield return new object[]
            {
                new VehicleScenario
                {
                    IdBranch = Guid.NewGuid(),
                    Name = "Delivery Truck",
                    Description = "A large truck used for deliveries",
                    LicensePlate = "ABC1234",
                    VehicleCondition = VehicleCondition.Working,
                    Price = 50000.0,
                    Gas = new List<Gas> { },
                    Employees = new List<Employee> { new Employee("John", "John", "John", "John", "John", "John", "John", 22.9, 2900, new(), new()) },
                    Branch = new Branch(Guid.NewGuid(),"Main Branch", "Main Branch",new Company(
                        "Valid Company",
                        "456 Business St",
                        "12345678000195",
                        new List<Branch>()), new()),
                    ExpectedIsValid = true
                }
            };

            yield return new object[]
            {
            new VehicleScenario
            {
                IdBranch = Guid.NewGuid(),
                Name = "Old Van",
                Description = "An old, well-used van",
                LicensePlate = "",
                VehicleCondition = VehicleCondition.Damaged,
                Price = 2000.0,
                Gas = new List<Gas> { },
                Employees = new List<Employee> { new Employee("John", "John", "John", "John", "John", "John", "John", 22.9, 2900, new(), new()) },
                Branch = new Branch(Guid.NewGuid(),"Main Branch", "Main Branch",new Company(
                    "Valid Company",
                    "456 Business St",
                    "12345678000195",
                    new List<Branch>()), new()),
                ExpectedIsValid = false
            }
            };

            yield return new object[]
            {
                new VehicleScenario
                {
                    IdBranch = Guid.Empty,
                    Name = "Electric Scooter",
                    Description = "A small electric scooter",
                    LicensePlate = "SCOOT123",
                    VehicleCondition = VehicleCondition.Working,
                    Price = 1500.0,
                    Gas = new List<Gas> {  },
                    Employees = new List<Employee>(),
                    Branch = new Branch(Guid.NewGuid(),"Main Branch", "Main Branch",new Company(
                        "Valid Company",
                        "456 Business St",
                        "12345678000195",
                        new List<Branch>()), new()),
                    ExpectedIsValid = false
                }
            };

        }
    }

}
