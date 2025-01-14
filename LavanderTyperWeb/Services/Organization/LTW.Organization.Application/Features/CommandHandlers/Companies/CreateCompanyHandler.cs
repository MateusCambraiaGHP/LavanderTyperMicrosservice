using AutoMapper;
using FluentValidation.Results;
using LTW.Core.Data;
using LTW.Core.Messages.CommonMessages;
using LTW.Organization.Application.Features.Commands.Companies;
using LTW.Organization.Application.Features.Responses.Companies;
using LTW.Organization.Application.Features.Validations.Companies;
using LTW.Organization.Application.Features.ViewModel.Companies;
using LTW.Organization.Domain.Primitives.Common.Interfaces.Repositories;
using LTW.Organization.Domain.Primitives.Entities.Companies;

namespace LTW.Organization.Application.Features.CommandHandlers.Companies
{
  public class CreateCompanyHandler : Handler<CreateCompanyCommand, CreateCompanyCommandResponse>
  {
    private readonly ICompanyRepository _companyRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateCompanyHandler(
        ICompanyRepository companyRepository,
        IMapper mapper,
        IUnitOfWork unitOfWork)
        : base(mapper)
    {
      _companyRepository = companyRepository;
      _unitOfWork = unitOfWork;
    }

    public override async Task<CreateCompanyCommandResponse> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
    {
      try
      {
        //await _loggerService.LogInfoAsync(
        //    request,
        //    "Start Handle Request",
        //    nameof(CreateCompanyHandler));
        request.ValidationResult = Validate(request);

        if (!request.IsValid())
          return ResponseOnFailValidation("fail on create company", request.ValidationResult);

        var company = new Company(
            request.Request.Name,
            request.Request.Address,
            request.Request.CNPJ,
            new());
        await _companyRepository.Create(company);
        await _unitOfWork.CommitChangesAsync();

        var companyViewModel = _mapper.Map<CompanyViewModel>(company);
        var response = new CreateCompanyCommandResponse(companyViewModel);

        //await _loggerService.LogInfoAsync(
        // null,
        // "End Handle Request",
        // nameof(CreateCompanyHandler),
        // response);

        return response;
      }
      catch (Exception ex)
      {
        return ResponseOnFailValidation(ex.Message, request.ValidationResult);
      }
    }

    public override List<ValidationFailure> Validate(CreateCompanyCommand request)
    {
      var validate = new CreateCompanyCommandValidation().Validate(request);
      return validate.Errors;
    }
  }
}
