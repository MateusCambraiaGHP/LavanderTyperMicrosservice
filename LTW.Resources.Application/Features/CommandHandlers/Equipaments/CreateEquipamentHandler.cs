using AutoMapper;
using FluentValidation.Results;
using LavanderTyperWeb.Application.Features.CommandHandlers.Branchs;
using LavanderTyperWeb.Application.Features.Validations.Employees;
using LavanderTyperWeb.Application.Features.Validations.Equipaments;
using LavanderTyperWeb.Core.Data;
using LavanderTyperWeb.Core.Messages.CommonMessages;
using LavanderTyperWeb.Domain.Primitives.Common.Interfaces.Repositories;
using LavanderTyperWeb.Domain.Primitives.Entities.Branchs;
using LavanderTyperWeb.Domain.Primitives.Entities.Equipaments;
using LavanderTyperWeb.Infrastructure.Loggers.Interfaces;
using LTW.Resources.Application.Features.Commands.Equipaments;
using LTW.Resources.Application.Features.Responses.Equipaments;
using LTW.Resources.Application.Features.ViewModel.Equipaments;

namespace LTW.Resources.Application.Features.CommandHandlers.Equipaments
{
  public class CreateEquipamentHandler : Handler<CreateEquipamentCommand, CreateEquipamentCommandResponse>
  {
    private readonly IEquipamentRepository _equipamentRepository;
    private readonly IBranchRepository _branchRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILoggerService _loggerService;

    public CreateEquipamentHandler(
        IEquipamentRepository equipamentRepository,
        IMapper mapper,
        IUnitOfWork unitOfWork,
        ILoggerService loggerService,
        IBranchRepository branchRepository)
        : base(mapper)
    {
      _equipamentRepository = equipamentRepository;
      _unitOfWork = unitOfWork;
      _loggerService = loggerService;
      _branchRepository = branchRepository;
    }

    public override async Task<CreateEquipamentCommandResponse> Handle(CreateEquipamentCommand request, CancellationToken cancellationToken)
    {
      try
      {
        await _loggerService.LogInfoAsync(
            request,
            "Start Handle Request",
            nameof(CreateEquipamentHandler));
        request.ValidationResult = Validate(request);

        if (!request.IsValid())
          return ResponseOnFailValidation("fail on create employee", request.ValidationResult);

        var currentBranch = await _branchRepository.GetAsync(ep => ep.Id == request.Request.IdBranch, null, null);
        var equipament = new Equipament(
            request.Request.IdBranch,
            currentBranch.First(),
            request.Request.Name,
            request.Request.Price,
            request.Request.Quantity,
            request.Request.Description);
        await _equipamentRepository.Create(equipament);
        await _unitOfWork.CommitChangesAsync();

        var equipamentViewModel = _mapper.Map<EquipamentViewModel>(equipament);
        var response = new CreateEquipamentCommandResponse(equipamentViewModel);

        await _loggerService.LogInfoAsync(
         null,
         "End Handle Request",
         nameof(CreateEquipamentHandler),
         response);

        return response;
      }
      catch (Exception ex)
      {
        return ResponseOnFailValidation(ex.Message, request.ValidationResult);
      }
    }

    public override List<ValidationFailure> Validate(CreateEquipamentCommand request)
    {
      var validate = new CreateEquipamentCommandValidation().Validate(request);
      return validate.Errors;
    }
  }
}
