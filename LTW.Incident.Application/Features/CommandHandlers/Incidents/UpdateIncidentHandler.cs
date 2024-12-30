using AutoMapper;
using FluentValidation.Results;
using LavanderTyperWeb.Application.Features.Validations.Incidents;
using LavanderTyperWeb.Core.Data;
using LavanderTyperWeb.Core.Messages.CommonMessages;
using LavanderTyperWeb.Data.Repositories;
using LavanderTyperWeb.Domain.Primitives.Common.Interfaces.Repositories;
using LavanderTyperWeb.Domain.Primitives.Entities.Incidents;
using LavanderTyperWeb.Infrastructure.Loggers.Interfaces;
using LTW.Incident.Application.Features.Commands.Incidents;
using LTW.Incident.Application.Features.Responses.Incidents;
using LTW.Incident.Application.Features.ViewModel.Incidents;

namespace LTW.Incident.Application.Features.CommandHandlers.Incidents
{
  public class UpdateIncidentHandler : Handler<UpdateIncidentCommand, UpdateIncidentCommandResponse>
  {
    private readonly IIncidentRepository _incidentRepository;
    private readonly ILoggerService _loggerService;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateIncidentHandler(
        IIncidentRepository incidentRepository,
        IUnitOfWork unitOfWork,
        IMapper mapper,
        ILoggerService loggerService)
        : base(mapper)
    {
      _incidentRepository = incidentRepository;
      _unitOfWork = unitOfWork;
      _loggerService = loggerService;
    }

    public override async Task<UpdateIncidentCommandResponse> Handle(UpdateIncidentCommand request, CancellationToken cancellationToken)
    {
      try
      {
        await _loggerService.LogInfoAsync(request,
            "Start Handle Request",
            nameof(UpdateIncidentHandler));
        request.ValidationResult = Validate(request);

        if (!request.IsValid())
          return ResponseOnFailValidation("fail on update employee", request.ValidationResult);
        Incident incidentMap = _mapper.Map<Incident>(request.Request);
        await _incidentRepository.Update(incidentMap);
        await _unitOfWork.CommitChangesAsync();
        var incidentViewModel = _mapper.Map<IncidentViewModel>(incidentMap);

        var response = new UpdateIncidentCommandResponse(incidentViewModel);
        await _loggerService.LogInfoAsync(null,
            "End Handle Request",
            nameof(UpdateIncidentHandler),
            response);

        return response;
      }
      catch (Exception ex)
      {
        return ResponseOnFailValidation(ex.Message, request.ValidationResult);
      }
    }

    public override List<ValidationFailure> Validate(UpdateIncidentCommand request)
    {
      var erros = new UpdateIncidentCommandValidation().Validate(request);
      return erros.Errors;
    }
  }
}
