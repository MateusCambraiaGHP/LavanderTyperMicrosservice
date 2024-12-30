namespace LTW.Organization.Application.Dtos.Employee
{
  public class CreateEmployeeDto
  {
    public List<Guid> IdsBranch { get; set; } = new();
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string Number { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string? Complements { get; set; }
    public string? LicenseNumber { get; set; }
    public double? SalaryPerHour { get; set; }
    public double? Salary { get; set; }
  }
}
