using FluentValidation;
using LTW.Incident.Application.Features.Commands.Incidents;

namespace LTW.Incident.Application.Features.Validations.Incidents
{
  public class CreateIncidentCommandValidation : AbstractValidator<CreateIncidentCommand>
  {
    public CreateIncidentCommandValidation()
    {
      RuleFor(c => c.Request.Description)
          .NotEmpty().WithMessage("The Description cannot be empty");
    }
  }
}
