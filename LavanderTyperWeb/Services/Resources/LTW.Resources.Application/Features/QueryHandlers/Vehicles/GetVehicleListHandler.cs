using AutoMapper;
using FluentValidation.Results;
using LTW.Core.Messages.CommonMessages;
using LTW.Resources.Application.Features.Queries.Vehicles;
using LTW.Resources.Application.Features.Responses.Vehicles;
using LTW.Resources.Application.Features.ViewModel.Vehicles;
using LTW.Resources.Domain.Primitives.Common.Interfaces.Repositories;

namespace LTW.Resources.Application.Features.QueryHandlers.Vehicles
{
  public class GetVehicleListHandler : Handler<GetVehicleListQuery, GetVehicleListQueryResponse>
  {
    private readonly IVehicleRepository _vehicleRepository;

    public GetVehicleListHandler(
        IMapper mapper,
        IVehicleRepository vehicleRepository)
        : base(mapper)
    {
      _vehicleRepository = vehicleRepository;
    }

    public override async Task<GetVehicleListQueryResponse> Handle(GetVehicleListQuery request, CancellationToken cancellationToken)
    {
      try
      {
        //await _loggerService.LogInfoAsync(
        //    request,
        //    "Start Handle Request",
        //    nameof(GetVehicleListHandler));


        var vehicleList = await _vehicleRepository.GetAsync(null, null, null);
        var vehicleListMap = _mapper.Map<List<VehicleViewModel>>(vehicleList);

        var response = new GetVehicleListQueryResponse(vehicleListMap);
        //await _loggerService.LogInfoAsync(
        //    null,
        //    "End Handle Request",
        //    nameof(GetVehicleListHandler),
        //    response);

        return response;
      }
      catch (Exception ex)
      {
        return ResponseOnFailValidation(ex.Message, request.ValidationResult);
      }
    }

    public override List<ValidationFailure> Validate(GetVehicleListQuery request)
    {
      throw new NotImplementedException();
    }
  }
}
