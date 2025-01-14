using LTW.Core.Messages.CommonMessages;
using LTW.Organization.Application.Features.ViewModel.Branchs;

namespace LTW.Organization.Application.Features.Responses.Branchs
{
  public class CreateBranchCommandResponse : BaseHandlerResponse
  {
    public BranchViewModel Response { get; set; } = new();

    public CreateBranchCommandResponse() { }

    public CreateBranchCommandResponse(BranchViewModel response)
        : base() => Response = response;

    public CreateBranchCommandResponse(bool success, string message = "")
        : base(success, message) { }
  }
}
