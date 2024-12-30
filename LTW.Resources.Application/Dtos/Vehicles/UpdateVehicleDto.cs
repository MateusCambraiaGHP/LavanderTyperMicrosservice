using LavanderTyperWeb.Application.Dtos.Branchs;
using LavanderTyperWeb.Application.Dtos.Employee;
using LavanderTyperWeb.Domain.Primitives.Entities.Branchs;
using LavanderTyperWeb.Domain.Primitives.Entities.Vehicles.Enums;
using LavanderTyperWeb.Domain.Primitives.Entities.Vehicles.ValueObjects;

namespace LTW.Resources.Application.Dtos.Vehicles
{
  public class UpdateVehicleDto
  {
    public Guid IdBranch { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string LicensePlate { get; set; } = string.Empty;
    public VehicleCondition? VehicleCondition { get; set; }
    public double? Price { get; set; }
    public List<Gas> Gas { get; set; } = new();
    public List<CreateEmployeeDto> Employees { get; set; } = new();
    public CreateBranchDto Branch { get; set; } = new();
  }
}
