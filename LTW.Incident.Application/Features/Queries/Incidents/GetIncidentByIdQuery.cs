using LavanderTyperWeb.Core.Messages.CommonMessages;
using LTW.Incident.Application.Features.Responses.Incidents;

namespace LTW.Incident.Application.Features.Queries.Incidents
{
  public class GetIncidentByIdQuery : Query<GetIncidentByIdQueryResponse>
  {
    public Guid Id { get; set; }

    public GetIncidentByIdQuery(Guid id) => Id = id;
  }
}
