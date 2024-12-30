using LavanderTyperWeb.Application.Features.ViewModel.Incidents;
using LavanderTyperWeb.Core.Messages.CommonMessages;

namespace LavanderTyperWeb.Application.Features.Responses.Incidents
{
    public class GetIncidentByIdQueryResponse : BaseHandlerResponse
    {
        public IncidentViewModel Response { get; set; } = new();

        public GetIncidentByIdQueryResponse()
            : base() { }

        public GetIncidentByIdQueryResponse(IncidentViewModel response)
            : base("Employee created sucess") => Response = response;

        public GetIncidentByIdQueryResponse(bool success, string message)
            : base(success, message) { }
    }
}
