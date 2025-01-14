using LTW.Core.Messages.CommonMessages;
using LTW.Resources.Application.Dtos.Vehicles;
using LTW.Resources.Application.Features.Responses.Vehicles;

namespace LTW.Resources.Application.Features.Commands.Vehicles
{
  public class CreateVehicleCommand : Command<CreateVehicleCommandResponse>
  {
    public CreateVehicleDto Request { get; init; }

    public CreateVehicleCommand(CreateVehicleDto request) => Request = request;
  }
}
