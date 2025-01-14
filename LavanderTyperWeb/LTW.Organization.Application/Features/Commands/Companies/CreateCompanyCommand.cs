using LTW.Core.Messages.CommonMessages;
using LTW.Organization.Application.Dtos.Companies;
using LTW.Organization.Application.Features.Responses.Companies;

namespace LTW.Organization.Application.Features.Commands.Companies
{
  public class CreateCompanyCommand : Command<CreateCompanyCommandResponse>
  {
    public CreateCompanyDto Request { get; init; }

    public CreateCompanyCommand(CreateCompanyDto request) => Request = request;
  }
}
