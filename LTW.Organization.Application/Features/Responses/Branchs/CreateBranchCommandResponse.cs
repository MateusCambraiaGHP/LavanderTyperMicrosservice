using LavanderTyperWeb.Application.Features.ViewModel.Branchs;
using LavanderTyperWeb.Core.Messages.CommonMessages;

namespace LavanderTyperWeb.Application.Features.Responses.Branchs
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
