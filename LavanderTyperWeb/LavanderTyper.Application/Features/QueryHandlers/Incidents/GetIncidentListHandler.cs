﻿using AutoMapper;
using FluentValidation.Results;
using LavanderTyperWeb.Application.Features.Queries.Incidents;
using LavanderTyperWeb.Application.Features.Responses.Incidents;
using LavanderTyperWeb.Application.Features.ViewModel.Incidents;
using LavanderTyperWeb.Core.Messages.CommonMessages;
using LavanderTyperWeb.Domain.Primitives.Common.Interfaces.Repositories;
using LavanderTyperWeb.Infrastructure.Loggers.Interfaces;

namespace LavanderTyperWeb.Application.Features.QueryHandlers.Incidents
{
    public class GetIncidentListHandler : Handler<GetIncidentListQuery, GetIncidentListQueryResponse>
    {
        private readonly IIncidentRepository _incidentRepository;
        private readonly ILoggerService _loggerService;

        public GetIncidentListHandler(
            IMapper mapper,
            ILoggerService loggerService,
            IIncidentRepository incidentRepository)
            : base(mapper)
        {
            _loggerService = loggerService;
            _incidentRepository = incidentRepository;
        }

        public override async Task<GetIncidentListQueryResponse> Handle(GetIncidentListQuery request, CancellationToken cancellationToken)
        {
            try
            {
                await _loggerService.LogInfoAsync(
                    request,
                    "Start Handle Request",
                    nameof(GetIncidentListHandler));


                var incidentList = await _incidentRepository.GetAsync(null, null, null);
                var incidentListMap = _mapper.Map<List<IncidentViewModel>>(incidentList);

                var response = new GetIncidentListQueryResponse(incidentListMap);
                await _loggerService.LogInfoAsync(
                    null,
                    "End Handle Request",
                    nameof(GetIncidentListHandler),
                    response);

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
