using LavanderTyperWeb.Application.Dtos.Incidents;
using LavanderTyperWeb.Application.Features.Responses.Incidents;
using LavanderTyperWeb.Core.Messages.CommonMessages;

namespace LavanderTyperWeb.Application.Features.Commands.Incidents
{
    public class CreateIncidentCommand : Command<CreateIncidentCommandResponse>
    {
        public CreateIncidentDto Request { get; init; }

        public CreateIncidentCommand(CreateIncidentDto request) => Request = request;
    }
}
