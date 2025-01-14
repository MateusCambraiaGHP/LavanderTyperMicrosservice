using LTW.Core.Messages.CommonMessages;
using LTW.Organization.Application.Dtos.Branchs;
using LTW.Organization.Application.Features.Responses.Branchs;

namespace LTW.Organization.Application.Features.Commands.Branchs
{
  public class CreateBranchCommand : Command<CreateBranchCommandResponse>
  {
    public CreateBranchDto Request { get; init; }

    public CreateBranchCommand(CreateBranchDto request) => Request = request;
  }
}
