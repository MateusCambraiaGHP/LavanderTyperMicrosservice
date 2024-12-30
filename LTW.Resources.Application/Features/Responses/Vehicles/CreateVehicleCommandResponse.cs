using LavanderTyperWeb.Application.Features.ViewModel.Vehicles;
using LavanderTyperWeb.Core.Messages.CommonMessages;

namespace LavanderTyperWeb.Application.Features.Responses.Vehicles
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
