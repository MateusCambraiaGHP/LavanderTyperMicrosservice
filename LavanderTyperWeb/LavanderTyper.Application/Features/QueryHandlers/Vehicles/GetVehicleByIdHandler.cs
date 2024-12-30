using AutoMapper;
using FluentValidation.Results;
using LavanderTyperWeb.Application.Features.Queries.Vehicles;
using LavanderTyperWeb.Application.Features.Responses.Vehicles;
using LavanderTyperWeb.Application.Features.ViewModel.Vehicles;
using LavanderTyperWeb.Core.Messages.CommonMessages;
using LavanderTyperWeb.Domain.Primitives.Common.Interfaces.Repositories;
using LavanderTyperWeb.Infrastructure.Loggers.Interfaces;

namespace LavanderTyperWeb.Application.Features.QueryHandlers.Vehicles
{
    public class GetVehicleByIdHandler : Handler<GetVehicleByIdQuery, GetVehicleByIdQueryResponse>
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly ILoggerService _loggerService;

        public GetVehicleByIdHandler(
            IMapper mapper,
            ILoggerService loggerService,
            IVehicleRepository vehicleRepository)
            : base(mapper)
        {
            _loggerService = loggerService;
            _vehicleRepository = vehicleRepository;
        }

        public override async Task<GetVehicleByIdQueryResponse> Handle(GetVehicleByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                await _loggerService.LogInfoAsync(
                    request,
                    "Start Handle Request",
                    nameof(GetVehicleByIdHandler));

                var currentVehicle = await _vehicleRepository.GetAsync(ep => ep.Id == request.Id, null, null);
                var vehicleMap = _mapper.Map<VehicleViewModel>(currentVehicle.FirstOrDefault());

                var response = new GetVehicleByIdQueryResponse(vehicleMap);
                await _loggerService.LogInfoAsync(
                    null,
                    "End Handle Request",
                    nameof(GetVehicleByIdHandler),
                    response);

                return response;
            }
            catch (Exception ex)
            {
                return ResponseOnFailValidation(ex.Message, request.ValidationResult);
            }
        }

        public override List<ValidationFailure> Validate(GetVehicleByIdQuery request)
        {
            throw new NotImplementedException();
        }
    }
}
