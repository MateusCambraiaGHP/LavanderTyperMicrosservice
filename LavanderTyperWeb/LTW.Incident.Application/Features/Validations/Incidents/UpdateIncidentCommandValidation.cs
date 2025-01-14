using FluentValidation;
using LTW.Incident.Application.Features.Commands.Incidents;

namespace LTW.Incident.Application.Features.Validations.Incidents
{
  public class UpdateIncidentCommandValidation : AbstractValidator<UpdateIncidentCommand>
  {
    public UpdateIncidentCommandValidation()
    {
      RuleFor(c => c.Request.Description)
          .NotEmpty().WithMessage("first name cannot be empty");
    }
  }
}
