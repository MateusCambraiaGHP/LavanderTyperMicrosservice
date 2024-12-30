using LavanderTyperWeb.Core.Messages.CommonMessages;
using LTW.Incident.Application.Dtos.Incidents;
using LTW.Incident.Application.Features.Responses.Incidents;

namespace LTW.Incident.Application.Features.Commands.Incidents
{
  public class CreateIncidentCommand : Command<CreateIncidentCommandResponse>
  {
    public CreateIncidentDto Request { get; init; }

    public CreateIncidentCommand(CreateIncidentDto request) => Request = request;
  }
}
