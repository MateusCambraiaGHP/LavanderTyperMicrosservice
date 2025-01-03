using LTW.Organization.Domain.Primitives.Entities.Branchs;

namespace LTW.Organization.Domain.Primitives.Entities.Employees
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
      Branches = branches;
    }
  }
}
