using LavanderTyperWeb.Core.DomainObjects;
using LavanderTyperWeb.Domain.Primitives.Entities.Branchs;
using LavanderTyperWeb.Domain.Primitives.Entities.Employees;
using LTW.Resources.Domain.Primitives.Entities.Vehicles.Enums;
using LTW.Resources.Domain.Primitives.Entities.Vehicles.ValueObjects;

namespace LTW.Resources.Domain.Primitives.Entities.Vehicles
{
  public class Vehicle : EntityBase
  {
    public Guid IdBranch { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string LicensePlate { get; set; } = string.Empty;
    public VehicleCondition? VehicleCondition { get; set; }
    public double? Price { get; set; }
    public List<Gas> Gas { get; set; } = new();
    public List<Employee> Employees { get; set; } = new();
    public Branch Branch { get; set; } = new();

    private Vehicle() { }

    public Vehicle(
        Guid idBranch,
        string name,
        string? description,
        string licensePlate,
        VehicleCondition? vehicleCondition,
        double? price,
        List<Gas> gas,
        List<Employee> employees,
        Branch branch)
    {
      IdBranch = idBranch;
      Name = name;
      Description = description;
      LicensePlate = licensePlate;
      VehicleCondition = vehicleCondition;
      Price = price;
      Gas = gas;
      Employees = employees;
      Branch = branch;
    }
  }
}
