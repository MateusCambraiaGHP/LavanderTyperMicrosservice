using LavanderTyperWeb.Application.Features.ViewModel.Branchs;
using LavanderTyperWeb.Application.Features.ViewModel.Vehicles;
using LavanderTyperWeb.Core.Messages.CommonMessages;

namespace LavanderTyperWeb.Application.Features.Responses.Branchs
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
