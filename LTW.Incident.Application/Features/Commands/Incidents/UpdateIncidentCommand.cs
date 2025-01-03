using LTW.Core.Messages.CommonMessages;
using LTW.Incident.Application.Dtos.Incidents;
using LTW.Incident.Application.Features.Responses.Incidents;

namespace LTW.Incident.Application.Features.Commands.Incidents
{
  public class UpdateIncidentCommand : Command<UpdateIncidentCommandResponse>
  {
    public UpdateIncidentDto Request { get; init; }

    public UpdateIncidentCommand(UpdateIncidentDto request) => Request = request;
  }
}
