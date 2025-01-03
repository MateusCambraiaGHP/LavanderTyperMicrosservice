using AutoMapper;
using FluentValidation.Results;
using LTW.Core.Messages.CommonMessages;
using LTW.Incident.Application.Features.Queries.Incidents;
using LTW.Incident.Application.Features.Responses.Incidents;
using LTW.Incident.Application.Features.ViewModel.Incidents;
using LTW.Incident.Domain.Primitives.Common.Interfaces.Repositories;

namespace LTW.Incident.Application.Features.QueryHandlers.Incidents
{
  public class GetIncidentListHandler : Handler<GetIncidentListQuery, GetIncidentListQueryResponse>
  {
    private readonly IIncidentRepository _incidentRepository;

    public GetIncidentListHandler(
        IMapper mapper,
        IIncidentRepository incidentRepository)
        : base(mapper)
    {
      _incidentRepository = incidentRepository;
    }

    public override async Task<GetIncidentListQueryResponse> Handle(GetIncidentListQuery request, CancellationToken cancellationToken)
    {
      try
      {
        //await _loggerService.LogInfoAsync(
        //    request,
        //    "Start Handle Request",
        //    nameof(GetIncidentListHandler));

        var incidentList = await _incidentRepository.GetAsync(null, null, null);
        var incidentListMap = _mapper.Map<List<IncidentViewModel>>(incidentList);

        var response = new GetIncidentListQueryResponse(incidentListMap);
        //await _loggerService.LogInfoAsync(
        //    null,
        //    "End Handle Request",
        //    nameof(GetIncidentListHandler),
        //    response);

        return response;
      }
      catch (Exception ex)
      {
        return ResponseOnFailValidation(ex.Message, request.ValidationResult);
      }
    }

    public override List<ValidationFailure> Validate(GetIncidentListQuery request)
    {
      throw new NotImplementedException();
    }
  }
}
