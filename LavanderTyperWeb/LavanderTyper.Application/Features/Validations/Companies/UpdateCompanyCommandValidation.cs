using FluentValidation;
using LavanderTyperWeb.Application.Features.Commands.Companies;

namespace LavanderTyperWeb.Application.Features.Validations.Companies
{
    public class UpdateCompanyCommandValidation : AbstractValidator<UpdateCompanyCommand>
    {
        public UpdateCompanyCommandValidation()
        {
            RuleFor(c => c.Request.Name)
                .NotEmpty().WithMessage("The first name cannot be empty");
            RuleFor(c => c.Request.Address)
                .NotEmpty().WithMessage("The first name cannot be empty");
        }
    }
}
