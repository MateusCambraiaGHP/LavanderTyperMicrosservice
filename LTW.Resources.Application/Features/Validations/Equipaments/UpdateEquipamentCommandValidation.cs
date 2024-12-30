using FluentValidation;
using LavanderTyperWeb.Application.Features.Commands.Equipaments;

namespace LavanderTyperWeb.Application.Features.Validations.Equipaments
{
    public class UpdateEquipamentCommandValidation : AbstractValidator<UpdateEquipamentCommand>
    {
        public UpdateEquipamentCommandValidation()
        {
            RuleFor(c => c.Request.Name)
                .NotEmpty().WithMessage("first name cannot be empty");
        }
    }
}
