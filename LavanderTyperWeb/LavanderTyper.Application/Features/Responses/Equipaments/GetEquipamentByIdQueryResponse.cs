using LavanderTyperWeb.Application.Features.ViewModel.Equipaments;
using LavanderTyperWeb.Application.Features.ViewModel.Vehicles;
using LavanderTyperWeb.Core.Messages.CommonMessages;

namespace LavanderTyperWeb.Application.Features.Responses.Equipaments
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
