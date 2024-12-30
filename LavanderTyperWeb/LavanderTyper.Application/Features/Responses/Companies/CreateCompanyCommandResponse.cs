using LavanderTyperWeb.Application.Features.ViewModel.Companies;
using LavanderTyperWeb.Core.Messages.CommonMessages;

namespace LavanderTyperWeb.Application.Features.Responses.Companies
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
