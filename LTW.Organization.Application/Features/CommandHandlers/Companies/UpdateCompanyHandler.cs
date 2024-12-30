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
    public class UpdateCompanyHandler : Handler<UpdateCompanyCommand, UpdateCompanyCommandResponse>
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly ILoggerService _loggerService;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateCompanyHandler(
            ICompanyRepository companyRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            ILoggerService loggerService)
            : base(mapper)
        {
            _companyRepository = companyRepository;
            _unitOfWork = unitOfWork;
            _loggerService = loggerService;
        }

        public override async Task<UpdateCompanyCommandResponse> Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _loggerService.LogInfoAsync(request,
                    "Start Handle Request",
                    nameof(UpdateCompanyHandler));
                request.ValidationResult = Validate(request);

                if (!request.IsValid())
                    return ResponseOnFailValidation("fail on update company", request.ValidationResult);

                Company companyMap = _mapper.Map<Company>(request.Request);
                await _companyRepository.Update(companyMap);
                await _unitOfWork.CommitChangesAsync();
                var companyViewModel = _mapper.Map<CompanyViewModel>(companyMap);

                var response = new UpdateCompanyCommandResponse(companyViewModel);
                await _loggerService.LogInfoAsync(null,
                    "End Handle Request",
                    nameof(UpdateCompanyHandler),
                    response);

                return response;
            }
            catch (Exception ex)
            {
                return ResponseOnFailValidation(ex.Message, request.ValidationResult);
            }
        }

        public override List<ValidationFailure> Validate(UpdateCompanyCommand request)
        {
            var erros = new UpdateCompanyCommandValidation().Validate(request);
            return erros.Errors;
        }
    }
}
