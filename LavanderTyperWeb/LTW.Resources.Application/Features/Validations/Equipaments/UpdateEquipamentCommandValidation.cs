using FluentValidation;
using LTW.Resources.Application.Features.Commands.Equipaments;

namespace LTW.Resources.Application.Features.Validations.Equipaments
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
