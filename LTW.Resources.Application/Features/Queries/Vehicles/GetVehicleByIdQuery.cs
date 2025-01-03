using LTW.Core.Messages.CommonMessages;
using LTW.Resources.Application.Features.Responses.Vehicles;

namespace LTW.Resources.Application.Features.Queries.Vehicles
{
  public class GetVehicleByIdQuery : Query<GetVehicleByIdQueryResponse>
  {
    public Guid Id { get; set; }

    public GetVehicleByIdQuery(Guid id) => Id = id;
  }
}
