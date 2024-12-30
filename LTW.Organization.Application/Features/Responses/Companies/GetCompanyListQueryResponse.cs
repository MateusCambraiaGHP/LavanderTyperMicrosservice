using LavanderTyperWeb.Core.Messages.CommonMessages;
using LTW.Organization.Application.Features.ViewModel.Companies;

namespace LTW.Organization.Application.Features.Responses.Companies
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
