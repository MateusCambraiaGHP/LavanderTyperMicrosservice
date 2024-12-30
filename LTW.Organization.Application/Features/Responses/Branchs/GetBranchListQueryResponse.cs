using LavanderTyperWeb.Application.Features.ViewModel.Branchs;
using LavanderTyperWeb.Core.Messages.CommonMessages;

namespace LavanderTyperWeb.Application.Features.Responses.Branchs
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
