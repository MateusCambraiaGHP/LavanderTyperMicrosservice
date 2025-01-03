using LTW.Core.Messages.CommonMessages;
using LTW.Organization.Application.Features.ViewModel.Branchs;

namespace LTW.Organization.Application.Features.Responses.Branchs
{
  public class GetBranchByIdQueryResponse : BaseHandlerResponse
  {
    public BranchViewModel Response { get; set; } = new();

    public GetBranchByIdQueryResponse()
        : base() { }

    public GetBranchByIdQueryResponse(BranchViewModel response)
        : base("Branch created sucess") => Response = response;

    public GetBranchByIdQueryResponse(bool success, string message)
        : base(success, message) { }
  }
}
