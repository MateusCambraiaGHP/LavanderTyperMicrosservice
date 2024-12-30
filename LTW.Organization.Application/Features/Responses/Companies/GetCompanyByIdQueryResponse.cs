using LavanderTyperWeb.Application.Features.ViewModel.Companies;
using LavanderTyperWeb.Core.Messages.CommonMessages;

namespace LavanderTyperWeb.Application.Features.Responses.Companies
{
    public class GetCompanyByIdQueryResponse : BaseHandlerResponse
    {
        public CompanyViewModel Response { get; set; } = new();

        public GetCompanyByIdQueryResponse()
            : base() { }

        public GetCompanyByIdQueryResponse(CompanyViewModel response)
            : base("Employee created sucess") => Response = response;

        public GetCompanyByIdQueryResponse(bool success, string message)
            : base(success, message) { }
    }
}
