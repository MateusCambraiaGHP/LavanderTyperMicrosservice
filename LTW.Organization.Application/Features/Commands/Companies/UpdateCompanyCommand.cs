using LTW.Core.Messages.CommonMessages;
using LTW.Organization.Application.Dtos.Companies;
using LTW.Organization.Application.Features.Responses.Companies;

namespace LTW.Organization.Application.Features.Commands.Companies
{
  public class UpdateCompanyCommand : Command<UpdateCompanyCommandResponse>
  {
    public UpdateCompanyDto Request { get; init; }

    public UpdateCompanyCommand(UpdateCompanyDto request) => Request = request;
  }
}
