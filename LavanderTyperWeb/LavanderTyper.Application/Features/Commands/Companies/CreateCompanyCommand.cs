using LavanderTyperWeb.Application.Dtos.Companies;
using LavanderTyperWeb.Application.Features.Responses.Companies;
using LavanderTyperWeb.Core.Messages.CommonMessages;

namespace LavanderTyperWeb.Application.Features.Commands.Companies
{
    public class CreateCompanyCommand : Command<CreateCompanyCommandResponse>
    {
        public CreateCompanyDto Request { get; init; }

        public CreateCompanyCommand(CreateCompanyDto request) => Request = request;
    }
}
