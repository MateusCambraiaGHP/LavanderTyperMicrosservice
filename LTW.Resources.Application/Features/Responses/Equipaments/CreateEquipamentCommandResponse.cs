using LavanderTyperWeb.Application.Features.ViewModel.Equipaments;
using LavanderTyperWeb.Core.Messages.CommonMessages;

namespace LavanderTyperWeb.Application.Features.Responses.Equipaments
{
    public class CreateEquipamentCommandResponse : BaseHandlerResponse
    {
        public EquipamentViewModel Response { get; set; } = new();

        public CreateEquipamentCommandResponse() { }

        public CreateEquipamentCommandResponse(EquipamentViewModel reponse)
            : base() => Response = reponse;

        public CreateEquipamentCommandResponse(bool success, string message = "")
            : base(success, message) { }
    }
}
