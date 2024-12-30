using LavanderTyperWeb.Application.Dtos.Vehicles;
using LavanderTyperWeb.Domain.Primitives.Entities.Branchs;
using LavanderTyperWeb.Domain.Primitives.Entities.Vehicles;
using LTW.Organization.Application.Dtos.Branchs;

namespace LTW.Organization.Application.Dtos.Employee
{
  public class UpdateEmployeeDto
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
    public List<CreateVehicleDto> Vehicles { get; set; } = new();
    public List<CreateBranchDto> Branches { get; set; } = new();
  }
}
