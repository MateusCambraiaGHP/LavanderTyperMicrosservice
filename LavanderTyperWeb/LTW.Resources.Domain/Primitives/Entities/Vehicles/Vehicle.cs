using LTW.Core.DomainObjects;
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

    private Vehicle() { }

    public Vehicle(
        Guid idBranch,
        string name,
        string? description,
        string licensePlate,
        VehicleCondition? vehicleCondition,
        double? price,
        List<Gas> gas)
    {
      IdBranch = idBranch;
      Name = name;
      Description = description;
      LicensePlate = licensePlate;
      VehicleCondition = vehicleCondition;
      Price = price;
      Gas = gas;
    }
  }
}
