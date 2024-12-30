using LavanderTyperWeb.Core.Messages.CommonMessages;
using LTW.Resources.Application.Dtos.Equipaments;
using LTW.Resources.Application.Features.Responses.Equipaments;

namespace LTW.Resources.Application.Features.Commands.Equipaments
{
  public class CreateEquipamentCommand : Command<CreateEquipamentCommandResponse>
  {
    public CreateEquipamentDto Request { get; init; }

    public CreateEquipamentCommand(CreateEquipamentDto request) => Request = request;
  }
}
