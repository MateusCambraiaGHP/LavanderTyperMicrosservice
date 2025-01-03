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
  public class UpdateVehicleHandler : Handler<UpdateVehicleCommand, UpdateVehicleCommandResponse>
  {
    private readonly IVehicleRepository _vehicleRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateVehicleHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IVehicleRepository vehicleRepository)
        : base(mapper)
    {
      _unitOfWork = unitOfWork;
      _vehicleRepository = vehicleRepository;
    }

    public override async Task<UpdateVehicleCommandResponse> Handle(UpdateVehicleCommand request, CancellationToken cancellationToken)
    {
      try
      {
        //await _loggerService.LogInfoAsync(request,
        //    "Start Handle Request",
        //    nameof(UpdateVehicleHandler));
        request.ValidationResult = Validate(request);

        if (!request.IsValid())
          return ResponseOnFailValidation("fail on update employee", request.ValidationResult);

        var vehicleMap = _mapper.Map<Vehicle>(request.Request);
        await _vehicleRepository.Update(vehicleMap);
        await _unitOfWork.CommitChangesAsync();
        var vehicleViewModel = _mapper.Map<VehicleViewModel>(vehicleMap);

        var response = new UpdateVehicleCommandResponse(vehicleViewModel);
        //await _loggerService.LogInfoAsync(null,
        //    "End Handle Request",
        //    nameof(UpdateVehicleHandler),
        //    response);

        return response;
      }
      catch (Exception ex)
      {
        return ResponseOnFailValidation(ex.Message, request.ValidationResult);
      }
    }

    public override List<ValidationFailure> Validate(UpdateVehicleCommand request)
    {
      var erros = new UpdateVehicleCommandValidation().Validate(request);
      return erros.Errors;
    }
  }
}
