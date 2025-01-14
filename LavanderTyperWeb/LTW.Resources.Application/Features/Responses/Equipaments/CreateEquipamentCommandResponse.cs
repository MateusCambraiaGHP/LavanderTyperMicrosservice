using LTW.Core.Messages.CommonMessages;
using LTW.Resources.Application.Features.ViewModel.Equipaments;

namespace LTW.Resources.Application.Features.Responses.Equipaments
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
