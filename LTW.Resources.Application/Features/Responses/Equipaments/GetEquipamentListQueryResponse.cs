using LavanderTyperWeb.Core.Messages.CommonMessages;
using LTW.Resources.Application.Features.ViewModel.Equipaments;

namespace LTW.Resources.Application.Features.Responses.Equipaments
{
  public class GetEquipamentListQueryResponse : BaseHandlerResponse
  {
    public List<EquipamentViewModel> Response { get; set; } = new();

    public GetEquipamentListQueryResponse()
        : base() { }

    public GetEquipamentListQueryResponse(List<EquipamentViewModel> response)
        : base() => Response = response;

    public GetEquipamentListQueryResponse(bool success, string message)
        : base(success, message) { }
  }
}
