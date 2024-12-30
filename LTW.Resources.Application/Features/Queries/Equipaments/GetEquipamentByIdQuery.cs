using LavanderTyperWeb.Core.Messages.CommonMessages;
using LTW.Resources.Application.Features.Responses.Equipaments;

namespace LTW.Resources.Application.Features.Queries.Equipaments
{
  public class GetEquipamentByIdQuery : Query<GetEquipamentByIdQueryResponse>
  {
    public Guid Id { get; set; }

    public GetEquipamentByIdQuery(Guid id) => Id = id;
  }
}
