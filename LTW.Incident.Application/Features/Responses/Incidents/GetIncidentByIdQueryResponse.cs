using LavanderTyperWeb.Core.Messages.CommonMessages;
using LTW.Incident.Application.Features.ViewModel.Incidents;

namespace LTW.Incident.Application.Features.Responses.Incidents
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
