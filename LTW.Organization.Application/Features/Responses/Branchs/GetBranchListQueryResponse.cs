using LavanderTyperWeb.Core.Messages.CommonMessages;
using LTW.Organization.Application.Features.ViewModel.Branchs;

namespace LTW.Organization.Application.Features.Responses.Branchs
{
  public class GetBranchListQueryResponse : BaseHandlerResponse
  {
    public List<BranchViewModel> Response { get; set; } = new();

    public GetBranchListQueryResponse()
        : base() { }

    public GetBranchListQueryResponse(List<BranchViewModel> response)
        : base() => Response = response;

    public GetBranchListQueryResponse(bool success, string message)
        : base(success, message) { }
  }
}
