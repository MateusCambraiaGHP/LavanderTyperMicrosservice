using LavanderTyperWeb.Application.Features.ViewModel.Incidents;
using LavanderTyperWeb.Core.Messages.CommonMessages;

namespace LavanderTyperWeb.Application.Features.Responses.Incidents
{
    public class CreateIncidentCommandResponse : BaseHandlerResponse
    {
        public IncidentViewModel Response { get; set; } = new();

        public CreateIncidentCommandResponse() { }

        public CreateIncidentCommandResponse(IncidentViewModel response)
            : base() => Response = response;

        public CreateIncidentCommandResponse(bool success, string message = "")
            : base(success, message) { }
    }
}
