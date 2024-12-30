using LavanderTyperWeb.Application.Dtos.Equipaments;
using LavanderTyperWeb.Application.Features.Responses.Equipaments;
using LavanderTyperWeb.Core.Messages.CommonMessages;

namespace LavanderTyperWeb.Application.Features.Commands.Equipaments
{
    public class CreateEquipamentCommand : Command<CreateEquipamentCommandResponse>
    {
        public CreateEquipamentDto Request { get; init; }

        public CreateEquipamentCommand(CreateEquipamentDto request) => Request = request;
    }
}
