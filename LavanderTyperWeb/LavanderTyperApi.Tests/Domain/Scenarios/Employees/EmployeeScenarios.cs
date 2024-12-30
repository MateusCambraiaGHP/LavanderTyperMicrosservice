using LavanderTyperWeb.Domain.Primitives.Entities.Branchs;
using LavanderTyperWeb.Domain.Primitives.Entities.Vehicles;

namespace LavanderTyperWeb.Tests.Domain.Scenarios.Employees
{
    public static class EmployeeScenarios
    {
        public static IEnumerable<object[]> GetScenarios()
        {
            yield return new object[]
            {
                new EmployeeScenario
                {
                    FirstName = "John",
                    LastName = "Doe",
                    Address = "456 Elm St",
                    Number = "123",
                    City = "Metropolis",
                    Complements = null,
                    LicenseNumber = "XYZ123456",
                    SalaryPerHour = 25.0,
                    Salary = null,
                    Vehicles = new List<Vehicle>(),
                    Branches = new List<Branch>(),
                    ExpectedIsValid = true
                }
            };

            yield return new object[]
            {
                new EmployeeScenario
                {
                    FirstName = "",
                    LastName = "Doe",
                    Address = "456 Elm St",
                    Number = "123",
                    City = "Metropolis",
                    Complements = "Apartment 4B",
                    LicenseNumber = "XYZ123456",
                    SalaryPerHour = null,
                    Salary = 50000.0,
                    Vehicles = new List<Vehicle>(),
                    Branches = new List<Branch>(),
                    ExpectedIsValid = false
                }
            };

            yield return new object[]
            {
                new EmployeeScenario
                {
                    FirstName = "Jane",
                    LastName = "Smith",
                    Address = "789 Oak St",
                    Number = "",
                    City = "Gotham",
                    Complements = null,
                    LicenseNumber = null,
                    SalaryPerHour = 30.0,
                    Salary = null,
                    Vehicles = new List<Vehicle>(),
                    Branches = new List<Branch>(),
                    ExpectedIsValid = false
                }
            };
        }
    }

}
