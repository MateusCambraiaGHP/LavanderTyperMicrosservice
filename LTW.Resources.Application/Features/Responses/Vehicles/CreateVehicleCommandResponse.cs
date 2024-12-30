using LavanderTyperWeb.Core.Messages.CommonMessages;
using LTW.Resources.Application.Features.ViewModel.Vehicles;

namespace LTW.Resources.Application.Features.Responses.Vehicles
{
  public class CreateVehicleCommandResponse : BaseHandlerResponse
  {
    public VehicleViewModel Employee { get; set; } = new();

    public CreateVehicleCommandResponse() { }

    public CreateVehicleCommandResponse(VehicleViewModel employee)
        : base() => Employee = employee;

    public CreateVehicleCommandResponse(bool success, string message = "")
        : base(success, message) { }
  }
}
