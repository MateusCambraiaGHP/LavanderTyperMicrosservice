using LavanderTyperWeb.Application.Features.Responses.Equipaments;
using LavanderTyperWeb.Core.Messages.CommonMessages;

namespace LavanderTyperWeb.Application.Features.Queries.Equipaments
{
    public class GetEquipamentByIdQuery : Query<GetEquipamentByIdQueryResponse>
    {
        public Guid Id { get; set; }

        public GetEquipamentByIdQuery(Guid id) => Id = id;
    }
}
