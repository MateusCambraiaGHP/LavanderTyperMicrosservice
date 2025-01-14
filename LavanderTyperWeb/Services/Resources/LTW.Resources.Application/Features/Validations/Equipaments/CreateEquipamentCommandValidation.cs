using FluentValidation;
using LTW.Resources.Application.Features.Commands.Equipaments;

namespace LTW.Resources.Application.Features.Validations.Equipaments
{
  public class CreateEquipamentCommandValidation : AbstractValidator<CreateEquipamentCommand>
  {
    public CreateEquipamentCommandValidation()
    {
      RuleFor(c => c.Request.Name)
          .NotEmpty().WithMessage("The first name cannot be empty");
    }
  }
}
