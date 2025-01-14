using AutoMapper;
using FluentValidation.Results;
using LTW.Core.Messages.CommonMessages;
using LTW.Incident.Application.Features.Queries.Incidents;
using LTW.Incident.Application.Features.Responses.Incidents;
using LTW.Incident.Application.Features.ViewModel.Incidents;
using LTW.Incident.Domain.Primitives.Common.Interfaces.Repositories;

namespace LTW.Incident.Application.Features.QueryHandlers.Incidents
{
  public class GetIncidentByIdHandler : Handler<GetIncidentByIdQuery, GetIncidentByIdQueryResponse>
  {
    private readonly IIncidentRepository _incidentRepository;

    public GetIncidentByIdHandler(
        IMapper mapper,
        IIncidentRepository incidentRepository)
        : base(mapper)
    {
      _incidentRepository = incidentRepository;
    }

    public override async Task<GetIncidentByIdQueryResponse> Handle(GetIncidentByIdQuery request, CancellationToken cancellationToken)
    {
      try
      {
        //await _loggerService.LogInfoAsync(
        //    request,
        //    "Start Handle Request",
        //    nameof(GetIncidentByIdHandler));

        var currentIncident = await _incidentRepository.GetAsync(ep => ep.Id == request.Id, null, null);
        var incidentMap = _mapper.Map<IncidentViewModel>(currentIncident.FirstOrDefault());

        var response = new GetIncidentByIdQueryResponse(incidentMap);
        //await _loggerService.LogInfoAsync(
        //    null,
        //    "End Handle Request",
        //    nameof(GetIncidentByIdHandler),
        //    response);

        return response;
      }
      catch (Exception ex)
      {
        return ResponseOnFailValidation(ex.Message, request.ValidationResult);
      }
    }

    public override List<ValidationFailure> Validate(GetIncidentByIdQuery request)
    {
      throw new NotImplementedException();
    }
  }
}
