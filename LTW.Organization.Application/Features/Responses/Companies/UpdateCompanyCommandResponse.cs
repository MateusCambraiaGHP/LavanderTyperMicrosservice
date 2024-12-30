using LavanderTyperWeb.Core.Messages.CommonMessages;
using LTW.Organization.Application.Features.ViewModel.Companies;

namespace LTW.Organization.Application.Features.Responses.Companies
{
  public class UpdateCompanyCommandResponse : BaseHandlerResponse
  {
    public CompanyViewModel Response { get; set; } = new();

    public UpdateCompanyCommandResponse() { }

    public UpdateCompanyCommandResponse(CompanyViewModel response)
        : base() => Response = response;

    public UpdateCompanyCommandResponse(bool success, string message = "")
        : base(success, message) { }
  }
}
