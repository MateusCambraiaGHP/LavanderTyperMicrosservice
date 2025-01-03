using LTW.Core.Messages.CommonMessages;
using LTW.Incident.Application.Features.ViewModel.Incidents;

namespace LTW.Incident.Application.Features.Responses.Incidents
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
