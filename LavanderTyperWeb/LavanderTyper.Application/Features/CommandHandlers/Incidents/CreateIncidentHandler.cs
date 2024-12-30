using AutoMapper;
using FluentValidation.Results;
using LavanderTyperWeb.Application.Features.Commands.Incidents;
using LavanderTyperWeb.Application.Features.Responses.Incidents;
using LavanderTyperWeb.Application.Features.Validations.Incidents;
using LavanderTyperWeb.Application.Features.ViewModel.Incidents;
using LavanderTyperWeb.Core.Data;
using LavanderTyperWeb.Core.Messages.CommonMessages;
using LavanderTyperWeb.Data.Repositories;
using LavanderTyperWeb.Domain.Primitives.Common.Interfaces.Repositories;
using LavanderTyperWeb.Domain.Primitives.Entities.Branchs;
using LavanderTyperWeb.Domain.Primitives.Entities.Equipaments;
using LavanderTyperWeb.Domain.Primitives.Entities.Incidents;
using LavanderTyperWeb.Infrastructure.Loggers.Interfaces;

namespace LavanderTyperWeb.Application.Features.CommandHandlers.Incidents
{
    public class CreateIncidentHandler : Handler<CreateIncidentCommand, CreateIncidentCommandResponse>
    {
        private readonly IIncidentRepository _incidentRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IEquipamentRepository _equipamentRepository;
        private readonly IBranchRepository _branchRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILoggerService _loggerService;

        public CreateIncidentHandler(
            IIncidentRepository incidentRepository,
            IMapper mapper,
            IUnitOfWork unitOfWork,
            ILoggerService loggerService,
            IEmployeeRepository employeeRepository,
            IEquipamentRepository equipamentRepository,
            IBranchRepository branchRepository)
            : base(mapper)
        {
            _incidentRepository = incidentRepository;
            _unitOfWork = unitOfWork;
            _loggerService = loggerService;
            _employeeRepository = employeeRepository;
            _equipamentRepository = equipamentRepository;
            _branchRepository = branchRepository;
        }

        public override async Task<CreateIncidentCommandResponse> Handle(CreateIncidentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _loggerService.LogInfoAsync(
                    request,
                    "Start Handle Request",
                    nameof(CreateIncidentHandler));
                request.ValidationResult = Validate(request);

                if (!request.IsValid())
                    return ResponseOnFailValidation("fail on create incident", request.ValidationResult);

                var currentEmployee = _employeeRepository.GetAsync(ep => ep.Id == request.Request.IdEmployee, null, null);
                var currentEquipament = _equipamentRepository.GetAsync(ep => ep.Id == request.Request.IdEquipament, null, null);
                var currentBranch = _branchRepository.GetAsync(ep => ep.Id == request.Request.IdBranch, null, null);
                await Task.WhenAll(currentEmployee, currentEquipament, currentBranch);
                var incident = new Incident(
                    request.Request.IdEmployee,
                    request.Request.IdBranch,
                    request.Request.IdEquipament,
                    currentEmployee.Result.First(),
                    currentEquipament.Result.FirstOrDefault(),
                    currentBranch.Result.First(),
                    request.Request.Date,
                    request.Request.Description,
                    request.Request.IncidentType);
                await _incidentRepository.Create(incident);
                await _unitOfWork.CommitChangesAsync();

                var incidentViewModel = _mapper.Map<IncidentViewModel>(incident);
                var response = new CreateIncidentCommandResponse(incidentViewModel);

                await _loggerService.LogInfoAsync(
                 null,
                 "End Handle Request",
                 nameof(CreateIncidentHandler),
                 response);

                return response;
            }
            catch (Exception ex)
            {
                return ResponseOnFailValidation(ex.Message, request.ValidationResult);
            }
        }

        public override List<ValidationFailure> Validate(CreateIncidentCommand request)
        {
            var validate = new CreateIncidentCommandValidation().Validate(request);
            return validate.Errors;
        }
    }
}
