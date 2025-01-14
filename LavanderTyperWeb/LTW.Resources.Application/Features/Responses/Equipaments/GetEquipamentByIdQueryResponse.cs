using LTW.Core.Messages.CommonMessages;
using LTW.Resources.Application.Features.ViewModel.Equipaments;

namespace LTW.Resources.Application.Features.Responses.Equipaments
{
  public class GetEquipamentByIdQueryResponse : BaseHandlerResponse
  {
    public EquipamentViewModel Response { get; set; } = new();

    public GetEquipamentByIdQueryResponse()
        : base() { }

    public GetEquipamentByIdQueryResponse(EquipamentViewModel response)
        : base("Employee created sucess") => Response = response;

    public GetEquipamentByIdQueryResponse(bool success, string message)
        : base(success, message) { }
  }
}
