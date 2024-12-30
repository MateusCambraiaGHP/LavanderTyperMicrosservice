using LavanderTyperWeb.Application.Features.ViewModel.Equipaments;
using LavanderTyperWeb.Core.Messages.CommonMessages;

namespace LavanderTyperWeb.Application.Features.Responses.Equipaments
{
    public class UpdateEquipamentCommandResponse : BaseHandlerResponse
    {
        public EquipamentViewModel Response { get; set; } = new();

        public UpdateEquipamentCommandResponse() { }

        public UpdateEquipamentCommandResponse(EquipamentViewModel response)
            : base() => Response = response;

        public UpdateEquipamentCommandResponse(bool success, string message = "")
            : base(success, message) { }
    }
}
