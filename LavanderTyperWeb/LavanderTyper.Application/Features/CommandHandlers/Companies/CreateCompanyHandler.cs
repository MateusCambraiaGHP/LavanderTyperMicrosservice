using AutoMapper;
using FluentValidation.Results;
using LavanderTyperWeb.Application.Features.Commands.Companies;
using LavanderTyperWeb.Application.Features.Responses.Companies;
using LavanderTyperWeb.Application.Features.Validations.Companies;
using LavanderTyperWeb.Application.Features.ViewModel.Companies;
using LavanderTyperWeb.Core.Data;
using LavanderTyperWeb.Core.Messages.CommonMessages;
using LavanderTyperWeb.Domain.Primitives.Common.Interfaces.Repositories;
using LavanderTyperWeb.Domain.Primitives.Entities.Companies;
using LavanderTyperWeb.Infrastructure.Loggers.Interfaces;

namespace LavanderTyperWeb.Application.Features.CommandHandlers.Companies
{
    public class CreateCompanyHandler : Handler<CreateCompanyCommand, CreateCompanyCommandResponse>
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILoggerService _loggerService;

        public CreateCompanyHandler(
            ICompanyRepository companyRepository,
            IMapper mapper,
            IUnitOfWork unitOfWork,
            ILoggerService loggerService)
            : base(mapper)
        {
            _companyRepository = companyRepository;
            _unitOfWork = unitOfWork;
            _loggerService = loggerService;
        }

        public override async Task<CreateCompanyCommandResponse> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _loggerService.LogInfoAsync(
                    request,
                    "Start Handle Request",
                    nameof(CreateCompanyHandler));
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

                await _loggerService.LogInfoAsync(
                 null,
                 "End Handle Request",
                 nameof(CreateCompanyHandler),
                 response);

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
