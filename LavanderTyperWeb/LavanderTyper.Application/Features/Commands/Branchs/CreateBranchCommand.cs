using LavanderTyperWeb.Application.Dtos.Branchs;
using LavanderTyperWeb.Application.Features.Responses.Branchs;
using LavanderTyperWeb.Core.Messages.CommonMessages;

namespace LavanderTyperWeb.Application.Features.Commands.Branchs
{
    public class CreateBranchCommand : Command<CreateBranchCommandResponse>
    {
        public CreateBranchDto Request { get; init; }

        public CreateBranchCommand(CreateBranchDto request) => Request = request;
    }
}
