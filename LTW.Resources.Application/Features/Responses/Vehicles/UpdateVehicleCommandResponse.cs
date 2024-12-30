using LavanderTyperWeb.Application.Features.ViewModel.Vehicles;
using LavanderTyperWeb.Core.Messages.CommonMessages;

namespace LavanderTyperWeb.Application.Features.Responses.Vehicles
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
