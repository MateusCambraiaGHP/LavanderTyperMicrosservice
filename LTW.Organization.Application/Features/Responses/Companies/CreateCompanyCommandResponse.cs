using LavanderTyperWeb.Core.Messages.CommonMessages;
using LTW.Organization.Application.Features.ViewModel.Companies;

namespace LTW.Organization.Application.Features.Responses.Companies
{
  public class CreateCompanyCommandResponse : BaseHandlerResponse
  {
    public CompanyViewModel Response { get; set; } = new();

    public CreateCompanyCommandResponse() { }

    public CreateCompanyCommandResponse(CompanyViewModel response)
        : base() => Response = response;

    public CreateCompanyCommandResponse(bool success, string message = "")
        : base(success, message) { }
  }
}
