using LavanderTyperWeb.Core.Messages.CommonMessages;
using LTW.Incident.Application.Features.ViewModel.Incidents;

namespace LTW.Incident.Application.Features.Responses.Incidents
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
