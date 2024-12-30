using LavanderTyperWeb.Application.Features.Responses.Incidents;
using LavanderTyperWeb.Core.Messages.CommonMessages;

namespace LavanderTyperWeb.Application.Features.Queries.Incidents
{
    public class GetIncidentByIdQuery : Query<GetIncidentByIdQueryResponse>
    {
        public Guid Id { get; set; }

        public GetIncidentByIdQuery(Guid id) => Id = id;
    }
}
