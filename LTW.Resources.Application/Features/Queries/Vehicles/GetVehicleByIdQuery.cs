using LavanderTyperWeb.Application.Features.Responses.Vehicles;
using LavanderTyperWeb.Core.Messages.CommonMessages;

namespace LavanderTyperWeb.Application.Features.Queries.Vehicles
{
    public class GetVehicleByIdQuery : Query<GetVehicleByIdQueryResponse>
    {
        public Guid Id { get; set; }

        public GetVehicleByIdQuery(Guid id) => Id = id;
    }
}
