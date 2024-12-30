using LavanderTyperWeb.Domain.Primitives.Entities.Branchs;
using LavanderTyperWeb.Domain.Primitives.Entities.Employees;
using LavanderTyperWeb.Domain.Primitives.Entities.Vehicles;
using LavanderTyperWeb.Tests.Domain.Scenarios.Common;

namespace LavanderTyperWeb.Tests.Domain.Scenarios.Employees
{
    public class EmployeeScenario : Scenario
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Number { get; set; }
        public string City { get; set; }
        public string? Complements { get; set; }
        public string? LicenseNumber { get; set; }
        public double? SalaryPerHour { get; set; }
        public double? Salary { get; set; }
        public List<Vehicle> Vehicles { get; set; }
        public List<Branch> Branches { get; set; }
        public bool ExpectedIsValid { get; set; }

        public Employee ToEmployee()
        {
            return new Employee(
                FirstName,
                LastName,
                Address,
                Number,
                City,
                Complements,
                LicenseNumber,
                SalaryPerHour,
                Salary,
                Vehicles,
                Branches);
        }
    }
}
