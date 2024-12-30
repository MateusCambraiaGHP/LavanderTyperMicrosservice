using LavanderTyperWeb.Application.Features.ViewModel.Incidents;
using LavanderTyperWeb.Core.Messages.CommonMessages;

namespace LavanderTyperWeb.Application.Features.Responses.Incidents
{
    public class UpdateIncidentCommandResponse : BaseHandlerResponse
    {
        public IncidentViewModel Response { get; set; } = new();

        public UpdateIncidentCommandResponse() { }

        public UpdateIncidentCommandResponse(IncidentViewModel response)
            : base() => Response = response;

        public UpdateIncidentCommandResponse(bool success, string message = "")
            : base(success, message) { }
    }
}
