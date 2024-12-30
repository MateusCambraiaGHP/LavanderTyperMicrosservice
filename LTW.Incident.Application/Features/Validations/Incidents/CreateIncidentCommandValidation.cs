using FluentValidation;
using LavanderTyperWeb.Application.Features.Commands.Incidents;

namespace LavanderTyperWeb.Application.Features.Validations.Incidents
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
