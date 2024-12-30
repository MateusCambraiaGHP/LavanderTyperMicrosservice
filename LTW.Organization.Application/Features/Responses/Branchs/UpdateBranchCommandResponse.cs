using LavanderTyperWeb.Core.Messages.CommonMessages;
using LTW.Organization.Application.Features.ViewModel.Branchs;

namespace LTW.Organization.Application.Features.Responses.Branchs
{
  public class UpdateBranchCommandResponse : BaseHandlerResponse
  {
    public BranchViewModel Response { get; set; } = new();

    public UpdateBranchCommandResponse() { }

    public UpdateBranchCommandResponse(BranchViewModel response)
        : base() => Response = response;

    public UpdateBranchCommandResponse(bool success, string message = "")
        : base(success, message) { }
  }
}
