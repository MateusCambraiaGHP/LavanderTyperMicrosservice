using AutoMapper;
using FluentValidation.Results;
using LTW.Core.Messages.CommonMessages;
using LTW.Resources.Application.Features.Queries.Vehicles;
using LTW.Resources.Application.Features.Responses.Vehicles;
using LTW.Resources.Application.Features.ViewModel.Vehicles;
using LTW.Resources.Domain.Primitives.Common.Interfaces.Repositories;

namespace LTW.Resources.Application.Features.QueryHandlers.Vehicles
{
  public class GetVehicleByIdHandler : Handler<GetVehicleByIdQuery, GetVehicleByIdQueryResponse>
  {
    private readonly IVehicleRepository _vehicleRepository;

    public GetVehicleByIdHandler(
        IMapper mapper,
        IVehicleRepository vehicleRepository)
        : base(mapper)
    {
      _vehicleRepository = vehicleRepository;
    }

    public override async Task<GetVehicleByIdQueryResponse> Handle(GetVehicleByIdQuery request, CancellationToken cancellationToken)
    {
      try
      {
        //await _loggerService.LogInfoAsync(
        //    request,
        //    "Start Handle Request",
        //    nameof(GetVehicleByIdHandler));

        var currentVehicle = await _vehicleRepository.GetAsync(ep => ep.Id == request.Id, null, null);
        var vehicleMap = _mapper.Map<VehicleViewModel>(currentVehicle.FirstOrDefault());

        var response = new GetVehicleByIdQueryResponse(vehicleMap);
        //await _loggerService.LogInfoAsync(
        //    null,
        //    "End Handle Request",
        //    nameof(GetVehicleByIdHandler),
        //    response);

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
