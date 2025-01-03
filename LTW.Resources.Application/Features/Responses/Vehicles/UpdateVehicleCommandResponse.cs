using LTW.Core.Messages.CommonMessages;
using LTW.Resources.Application.Features.ViewModel.Vehicles;

namespace LTW.Resources.Application.Features.Responses.Vehicles
{
  public class UpdateVehicleCommandResponse : BaseHandlerResponse
  {
    public VehicleViewModel Employee { get; set; } = new();

    public UpdateVehicleCommandResponse() { }

    public UpdateVehicleCommandResponse(VehicleViewModel employee)
        : base() => Employee = employee;

    public UpdateVehicleCommandResponse(bool success, string message = "")
        : base(success, message) { }
  }
}
