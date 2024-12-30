using FluentValidation;
using LavanderTyperWeb.Application.Features.Commands.Branchs;

namespace LavanderTyperWeb.Application.Features.Validations.Branchs
{
    public class CreateBranchCommandValidation : AbstractValidator<CreateBranchCommand>
    {
        public CreateBranchCommandValidation()
        {
            RuleFor(c => c.Request.Name)
                .NotEmpty().WithMessage("The first name cannot be empty");
            RuleFor(c => c.Request.Address)
                .NotEmpty().WithMessage("The first name cannot be empty");
        }
    }
}
