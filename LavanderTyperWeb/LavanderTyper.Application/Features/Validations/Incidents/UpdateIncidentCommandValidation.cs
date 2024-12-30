using FluentValidation;
using LavanderTyperWeb.Application.Features.Commands.Incidents;

namespace LavanderTyperWeb.Application.Features.Validations.Incidents
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
