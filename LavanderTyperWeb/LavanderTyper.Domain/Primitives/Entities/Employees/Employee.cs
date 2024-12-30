using LavanderTyperWeb.Domain.Primitives.Entities.Branchs;
using LavanderTyperWeb.Domain.Primitives.Entities.Vehicles;

namespace LavanderTyperWeb.Domain.Primitives.Entities.Employees
{
    public class Employee : AggregateRoot
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Number { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string? Complements { get; set; }
        public string? LicenseNumber { get; set; }
        public double? SalaryPerHour { get; set; }
        public double? Salary { get; set; }
        public List<Vehicle> Vehicles { get; set; } = new();
        public List<Branch> Branches { get; set; } = new();

        internal Employee() { }

        public Employee(
            string firstName,
            string lastName,
            string address,
            string number,
            string city,
            string? complements,
            string? licenseNumber,
            double? salaryPerHour,
            double? salary,
            List<Vehicle> vehicles,
            List<Branch> branches)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            Number = number;
            City = city;
            Complements = complements;
            LicenseNumber = licenseNumber;
            SalaryPerHour = salaryPerHour;
            Salary = salary;
            Vehicles = vehicles;
            Branches = branches;
        }
    }
}
