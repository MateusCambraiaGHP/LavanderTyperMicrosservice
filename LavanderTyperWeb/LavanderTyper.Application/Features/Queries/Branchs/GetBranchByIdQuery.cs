using LavanderTyperWeb.Application.Features.Responses.Branchs;
using LavanderTyperWeb.Core.Messages.CommonMessages;

namespace LavanderTyperWeb.Application.Features.Queries.Branchs
{
    public class GetBranchByIdQuery : Query<GetBranchByIdQueryResponse>
    {
        public Guid Id { get; set; }

        public GetBranchByIdQuery(Guid id) => Id = id;
    }
}
