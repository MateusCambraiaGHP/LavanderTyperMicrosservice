using LavanderTyperWeb.Core.Messages.CommonMessages;
using LTW.Organization.Application.Dtos.Branchs;
using LTW.Organization.Application.Features.Responses.Branchs;

namespace LTW.Organization.Application.Features.Commands.Branchs
{
  public class UpdateBranchCommand : Command<UpdateBranchCommandResponse>
  {
    public UpdateBranchDto Request { get; init; }

    public UpdateBranchCommand(UpdateBranchDto request) => Request = request;
  }
}
