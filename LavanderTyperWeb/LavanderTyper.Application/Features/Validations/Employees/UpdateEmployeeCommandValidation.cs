using FluentValidation;
using LavanderTyperWeb.Application.Features.Commands.Employee;

namespace LavanderTyperWeb.Application.Features.Validations.Employees
{
    public class UpdateEmployeeCommandValidation : AbstractValidator<UpdateEmployeeCommand>
    {
        public UpdateEmployeeCommandValidation()
        {
            RuleFor(c => c.Request.FirstName)
                 .NotEmpty().WithMessage("The first name cannot be empty");
            RuleFor(c => c.Request.LastName) 
                .NotEmpty().WithMessage("The last name cannot be empty");
            RuleFor(c => c.Request.Address)
                .NotEmpty().WithMessage("The adress cannot be empty");
            RuleFor(c => c.Request.Number)
                .NotEmpty().WithMessage("The number cannot be empty");
            RuleFor(c => c.Request.City)
                .NotEmpty().WithMessage("The city cannot be empty");
        }
    }
}
