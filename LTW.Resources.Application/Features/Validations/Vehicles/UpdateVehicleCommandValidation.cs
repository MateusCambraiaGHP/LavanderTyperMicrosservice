using FluentValidation;
using LavanderTyperWeb.Application.Features.Commands.Vehicles;

namespace LavanderTyperWeb.Application.Features.Validations.Vehicles
{
    public class UpdateVehicleCommandValidation : AbstractValidator<UpdateVehicleCommand>
    {
        public UpdateVehicleCommandValidation()
        {
            RuleFor(c => c.Request.Name)
                .NotEmpty().WithMessage("The first name cannot be empty");
            RuleFor(c => c.Request.LicensePlate)
                .NotEmpty().WithMessage("first name cannot be empty");
        }
    }
}
