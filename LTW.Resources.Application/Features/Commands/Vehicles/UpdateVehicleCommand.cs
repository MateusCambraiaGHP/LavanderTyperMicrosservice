using LavanderTyperWeb.Application.Dtos.Vehicles;
using LavanderTyperWeb.Application.Features.Responses.Vehicles;
using LavanderTyperWeb.Core.Messages.CommonMessages;

namespace LavanderTyperWeb.Application.Features.Commands.Vehicles
{
    public class UpdateVehicleCommand : Command<UpdateVehicleCommandResponse>
    {
        public UpdateVehicleDto Request { get; init; }

        public UpdateVehicleCommand(UpdateVehicleDto request) => Request = request;
    }
}
