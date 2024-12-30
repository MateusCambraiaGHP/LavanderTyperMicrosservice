using LavanderTyperWeb.Application.Features.ViewModel.Incidents;
using LavanderTyperWeb.Core.Messages.CommonMessages;

namespace LavanderTyperWeb.Application.Features.Responses.Incidents
{
    public class GetIncidentListQueryResponse : BaseHandlerResponse
    {
        public List<IncidentViewModel> Response { get; set; } = new();

        public GetIncidentListQueryResponse()
            : base() { }

        public GetIncidentListQueryResponse(List<IncidentViewModel> response)
            : base() => Response = response;

        public GetIncidentListQueryResponse(bool success, string message)
            : base(success, message) { }
    }
}
