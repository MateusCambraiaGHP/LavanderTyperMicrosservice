using FluentValidation;
using LTW.Resources.Application.Features.Commands.Vehicles;

namespace LTW.Resources.Application.Features.Validations.Vehicles
{
  public class CreateVehicleCommandValidation : AbstractValidator<CreateVehicleCommand>
  {
    public CreateVehicleCommandValidation()
    {
      RuleFor(c => c.Request.Name)
          .NotEmpty().WithMessage("The first name cannot be empty");
      RuleFor(c => c.Request.LicensePlate)
          .NotEmpty().WithMessage("The license plate cannot be empty");
    }
  }
}
