using AutoMapper;
using FluentValidation.Results;
using LTW.Core.Data;
using LTW.Core.Messages.CommonMessages;
using LTW.Resources.Application.Features.Commands.Vehicles;
using LTW.Resources.Application.Features.Responses.Vehicles;
using LTW.Resources.Application.Features.Validations.Vehicles;
using LTW.Resources.Application.Features.ViewModel.Vehicles;
using LTW.Resources.Domain.Primitives.Common.Interfaces.Repositories;
using LTW.Resources.Domain.Primitives.Entities.Vehicles;

namespace LTW.Resources.Application.Features.CommandHandlers.Vehicles
{
  public class CreateVehicleHandler : Handler<CreateVehicleCommand, CreateVehicleCommandResponse>
  {
    private readonly IVehicleRepository _vehicleRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateVehicleHandler(
        IVehicleRepository vehicleRepository,
        IMapper mapper,
        IUnitOfWork unitOfWork)
        : base(mapper)
    {
      _vehicleRepository = vehicleRepository;
      _unitOfWork = unitOfWork;
    }

    public override async Task<CreateVehicleCommandResponse> Handle(CreateVehicleCommand request, CancellationToken cancellationToken)
    {
      try
      {
        //await _loggerService.LogInfoAsync(
        //    request,
        //    "Start Handle Request",
        //    nameof(CreateVehicleHandler));
        request.ValidationResult = Validate(request);

        if (!request.IsValid())
          return ResponseOnFailValidation("fail on create employee", request.ValidationResult);

        var vehicle = new Vehicle(
            request.Request.IdBranch,
            request.Request.Name,
            request.Request.Description,
            request.Request.LicensePlate,
            request.Request.VehicleCondition,
            request.Request.Price,
            request.Request.Gas);
        await _vehicleRepository.Create(vehicle);
        await _unitOfWork.CommitChangesAsync();

        var vehicleViewModel = _mapper.Map<VehicleViewModel>(vehicle);
        var response = new CreateVehicleCommandResponse(vehicleViewModel);

        //await _loggerService.LogInfoAsync(
        // null,
        // "End Handle Request",
        // nameof(CreateVehicleHandler),
        // response);

        return response;
      }
      catch (Exception ex)
      {
        return ResponseOnFailValidation(ex.Message, request.ValidationResult);
      }
    }

    public override List<ValidationFailure> Validate(CreateVehicleCommand request)
    {
      var validate = new CreateVehicleCommandValidation().Validate(request);
      return validate.Errors;
    }
  }
}
