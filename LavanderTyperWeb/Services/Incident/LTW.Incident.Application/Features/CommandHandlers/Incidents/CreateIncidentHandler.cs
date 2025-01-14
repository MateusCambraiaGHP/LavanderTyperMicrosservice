using AutoMapper;
using FluentValidation.Results;
using LTW.Core.Data;
using LTW.Core.Messages.CommonMessages;
using LTW.Incident.Application.Features.Commands.Incidents;
using LTW.Incident.Application.Features.Responses.Incidents;
using LTW.Incident.Application.Features.Validations.Incidents;
using LTW.Incident.Application.Features.ViewModel.Incidents;
using LTW.Incident.Domain.Primitives.Common.Interfaces.Repositories;
using IncidentEntity = LTW.Incident.Domain.Primitives.Entities.Incidents.Incident;

namespace LTW.Incidents.Application.Features.CommandHandlers.Incidents
{
  public class CreateIncidentHandler : Handler<CreateIncidentCommand, CreateIncidentCommandResponse>
  {
    private readonly IIncidentRepository _incidentRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateIncidentHandler(
        IIncidentRepository incidentRepository,
        IMapper mapper,
        IUnitOfWork unitOfWork)
        : base(mapper)
    {
      _incidentRepository = incidentRepository;
      _unitOfWork = unitOfWork;
    }

    public override async Task<CreateIncidentCommandResponse> Handle(CreateIncidentCommand request, CancellationToken cancellationToken)
    {
      try
      {
        //await _loggerService.LogInfoAsync(
        //    request,
        //    "Start Handle Request",
        //    nameof(CreateIncidentHandler));
        request.ValidationResult = Validate(request);

        if (!request.IsValid())
          return ResponseOnFailValidation("fail on create incident", request.ValidationResult);

        var incident = new IncidentEntity(
            request.Request.IdEmployee,
            request.Request.IdBranch,
            request.Request.IdEquipament,
            request.Request.Date,
            request.Request.Description,
            request.Request.IncidentType);
        await _incidentRepository.Create(incident);
        await _unitOfWork.CommitChangesAsync();

        var incidentViewModel = _mapper.Map<IncidentViewModel>(incident);
        var response = new CreateIncidentCommandResponse(incidentViewModel);

        //await _loggerService.LogInfoAsync(
        // null,
        // "End Handle Request",
        // nameof(CreateIncidentHandler),
        // response);

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
