using LavanderTyperWeb.Application.Dtos.Vehicles;
using LavanderTyperWeb.Application.Features.Responses.Vehicles;
using LavanderTyperWeb.Core.Messages.CommonMessages;

namespace LavanderTyperWeb.Application.Features.Commands.Vehicles
{
    public class CreateVehicleCommand : Command<CreateVehicleCommandResponse>
    {
        public CreateVehicleDto Request { get; init; }

        public CreateVehicleCommand(CreateVehicleDto request) => Request = request;
    }
}
