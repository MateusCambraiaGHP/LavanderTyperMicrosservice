using LavanderTyperWeb.Core.Messages.CommonMessages;
using LTW.Incident.Application.Features.ViewModel.Incidents;

namespace LTW.Incident.Application.Features.Responses.Incidents
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
