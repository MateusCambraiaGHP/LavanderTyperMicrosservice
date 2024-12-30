using LavanderTyperWeb.Core.Messages.CommonMessages;
using LTW.Organization.Application.Features.Responses.Branchs;

namespace LTW.Organization.Application.Features.Queries.Branchs
{
  public class GetBranchByIdQuery : Query<GetBranchByIdQueryResponse>
  {
    public Guid Id { get; set; }

    public GetBranchByIdQuery(Guid id) => Id = id;
  }
}
