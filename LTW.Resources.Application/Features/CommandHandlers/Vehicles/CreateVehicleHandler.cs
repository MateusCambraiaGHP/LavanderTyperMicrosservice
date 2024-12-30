using AutoMapper;
using FluentValidation.Results;
using LavanderTyperWeb.Application.Features.Validations.Vehicles;
using LavanderTyperWeb.Core.Data;
using LavanderTyperWeb.Core.Messages.CommonMessages;
using LavanderTyperWeb.Domain.Primitives.Common.Interfaces.Repositories;
using LavanderTyperWeb.Domain.Primitives.Entities.Vehicles;
using LavanderTyperWeb.Infrastructure.Loggers.Interfaces;
using LTW.Resources.Application.Features.Commands.Vehicles;
using LTW.Resources.Application.Features.Responses.Vehicles;
using LTW.Resources.Application.Features.ViewModel.Vehicles;

namespace LTW.Resources.Application.Features.CommandHandlers.Vehicles
{
  public class CreateVehicleHandler : Handler<CreateVehicleCommand, CreateVehicleCommandResponse>
  {
    private readonly IVehicleRepository _vehicleRepository;
    private readonly IBranchRepository _branchRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILoggerService _loggerService;

    public CreateVehicleHandler(
        IVehicleRepository vehicleRepository,
        IMapper mapper,
        IUnitOfWork unitOfWork,
        ILoggerService loggerService,
        IBranchRepository branchRepository)
        : base(mapper)
    {
      _vehicleRepository = vehicleRepository;
      _unitOfWork = unitOfWork;
      _loggerService = loggerService;
      _branchRepository = branchRepository;
    }

    public override async Task<CreateVehicleCommandResponse> Handle(CreateVehicleCommand request, CancellationToken cancellationToken)
    {
      try
      {
        await _loggerService.LogInfoAsync(
            request,
            "Start Handle Request",
            nameof(CreateVehicleHandler));
        request.ValidationResult = Validate(request);

        if (!request.IsValid())
          return ResponseOnFailValidation("fail on create employee", request.ValidationResult);

        var currentBranch = await _branchRepository.GetAsync(ep => ep.Id == request.Request.IdBranch, null, null);
        var vehicle = new Vehicle(
            request.Request.IdBranch,
            request.Request.Name,
            request.Request.Description,
            request.Request.LicensePlate,
            request.Request.VehicleCondition,
            request.Request.Price,
            request.Request.Gas,
            new(),
            currentBranch.First());
        await _vehicleRepository.Create(vehicle);
        await _unitOfWork.CommitChangesAsync();

        var vehicleViewModel = _mapper.Map<VehicleViewModel>(vehicle);
        var response = new CreateVehicleCommandResponse(vehicleViewModel);

        await _loggerService.LogInfoAsync(
         null,
         "End Handle Request",
         nameof(CreateVehicleHandler),
         response);

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
