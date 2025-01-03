using LTW.Core.Messages.CommonMessages;
using LTW.Resources.Application.Dtos.Equipaments;
using LTW.Resources.Application.Features.Responses.Equipaments;

namespace LTW.Resources.Application.Features.Commands.Equipaments
{
  public class UpdateEquipamentCommand : Command<UpdateEquipamentCommandResponse>
  {
    public UpdateEquipamentDto Request { get; init; }

    public UpdateEquipamentCommand(UpdateEquipamentDto request) => Request = request;
  }
}
