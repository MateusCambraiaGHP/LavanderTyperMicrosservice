using LavanderTyperWeb.Core.Messages.CommonMessages;
using LTW.Resources.Application.Dtos.Vehicles;
using LTW.Resources.Application.Features.Responses.Vehicles;

namespace LTW.Resources.Application.Features.Commands.Vehicles
{
  public class UpdateVehicleCommand : Command<UpdateVehicleCommandResponse>
  {
    public UpdateVehicleDto Request { get; init; }

    public UpdateVehicleCommand(UpdateVehicleDto request) => Request = request;
  }
}
