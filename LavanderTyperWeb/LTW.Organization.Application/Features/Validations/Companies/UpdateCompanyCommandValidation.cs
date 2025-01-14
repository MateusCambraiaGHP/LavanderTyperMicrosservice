using FluentValidation;
using LTW.Organization.Application.Features.Commands.Companies;

namespace LTW.Organization.Application.Features.Validations.Companies
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
