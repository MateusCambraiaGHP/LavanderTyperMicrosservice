using LavanderTyperWeb.Application.Dtos.Incidents;
using LavanderTyperWeb.Application.Features.Responses.Incidents;
using LavanderTyperWeb.Core.Messages.CommonMessages;

namespace LavanderTyperWeb.Application.Features.Commands.Incidents
{
    public class UpdateIncidentCommand : Command<UpdateIncidentCommandResponse>
    {
        public UpdateIncidentDto Request { get; init; }

        public UpdateIncidentCommand(UpdateIncidentDto request) => Request = request;
    }
}
