using LavanderTyperWeb.Application.Dtos.Companies;
using LavanderTyperWeb.Application.Features.Responses.Companies;
using LavanderTyperWeb.Core.Messages.CommonMessages;

namespace LavanderTyperWeb.Application.Features.Commands.Companies
{
    public class UpdateCompanyCommand : Command<UpdateCompanyCommandResponse>
    {
        public UpdateCompanyDto Request { get; init; }

        public UpdateCompanyCommand(UpdateCompanyDto request) => Request = request;
    }
}
