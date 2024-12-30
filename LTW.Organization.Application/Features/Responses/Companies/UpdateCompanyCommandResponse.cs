using LavanderTyperWeb.Application.Features.ViewModel.Companies;
using LavanderTyperWeb.Core.Messages.CommonMessages;

namespace LavanderTyperWeb.Application.Features.Responses.Companies
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
