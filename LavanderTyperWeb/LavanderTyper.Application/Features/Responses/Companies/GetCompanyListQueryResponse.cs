using LavanderTyperWeb.Application.Features.ViewModel.Companies;
using LavanderTyperWeb.Core.Messages.CommonMessages;

namespace LavanderTyperWeb.Application.Features.Responses.Companies
{
    public class GetCompanyListQueryResponse : BaseHandlerResponse
    {
        public List<CompanyViewModel> Response { get; set; } = new();

        public GetCompanyListQueryResponse()
            : base() { }

        public GetCompanyListQueryResponse(List<CompanyViewModel> response)
            : base() => Response = response;

        public GetCompanyListQueryResponse(bool success, string message)
            : base(success, message) { }
    }
}
