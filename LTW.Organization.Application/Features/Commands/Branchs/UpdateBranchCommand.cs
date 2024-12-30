using LavanderTyperWeb.Application.Dtos.Branchs;
using LavanderTyperWeb.Application.Features.Responses.Branchs;
using LavanderTyperWeb.Core.Messages.CommonMessages;

namespace LavanderTyperWeb.Application.Features.Commands.Branchs
{
    public class UpdateBranchCommand : Command<UpdateBranchCommandResponse>
    {
        public UpdateBranchDto Request { get; init; }

        public UpdateBranchCommand(UpdateBranchDto request) => Request = request;
    }
}
