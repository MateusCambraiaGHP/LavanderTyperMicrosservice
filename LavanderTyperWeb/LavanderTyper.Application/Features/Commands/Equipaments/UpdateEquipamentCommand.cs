using LavanderTyperWeb.Application.Dtos.Equipaments;
using LavanderTyperWeb.Application.Features.Responses.Equipaments;
using LavanderTyperWeb.Core.Messages.CommonMessages;

namespace LavanderTyperWeb.Application.Features.Commands.Equipaments
{
    public class UpdateEquipamentCommand : Command<UpdateEquipamentCommandResponse>
    {
        public UpdateEquipamentDto Request { get; init; }

        public UpdateEquipamentCommand(UpdateEquipamentDto request) => Request = request;
    }
}
