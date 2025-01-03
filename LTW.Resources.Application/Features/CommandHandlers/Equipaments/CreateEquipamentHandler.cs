using AutoMapper;
using FluentValidation.Results;
using LTW.Core.Data;
using LTW.Core.Messages.CommonMessages;
using LTW.Resources.Application.Features.Commands.Equipaments;
using LTW.Resources.Application.Features.Responses.Equipaments;
using LTW.Resources.Application.Features.Validations.Equipaments;
using LTW.Resources.Application.Features.ViewModel.Equipaments;
using LTW.Resources.Domain.Primitives.Common.Interfaces.Repositories;
using LTW.Resources.Domain.Primitives.Entities.Equipaments;

namespace LTW.Resources.Application.Features.CommandHandlers.Equipaments
{
  public class CreateEquipamentHandler : Handler<CreateEquipamentCommand, CreateEquipamentCommandResponse>
  {
    private readonly IEquipamentRepository _equipamentRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateEquipamentHandler(
        IEquipamentRepository equipamentRepository,
        IMapper mapper,
        IUnitOfWork unitOfWork)
        : base(mapper)
    {
      _equipamentRepository = equipamentRepository;
      _unitOfWork = unitOfWork;
    }

    public override async Task<CreateEquipamentCommandResponse> Handle(CreateEquipamentCommand request, CancellationToken cancellationToken)
    {
      try
      {
        //await _loggerService.LogInfoAsync(
        //    request,
        //    "Start Handle Request",
        //    nameof(CreateEquipamentHandler));
        request.ValidationResult = Validate(request);

        if (!request.IsValid())
          return ResponseOnFailValidation("fail on create employee", request.ValidationResult);

        var equipament = new Equipament(
            request.Request.IdBranch,
            request.Request.Name,
            request.Request.Price,
            request.Request.Quantity,
            request.Request.Description);
        await _equipamentRepository.Create(equipament);
        await _unitOfWork.CommitChangesAsync();

        var equipamentViewModel = _mapper.Map<EquipamentViewModel>(equipament);
        var response = new CreateEquipamentCommandResponse(equipamentViewModel);

        //await _loggerService.LogInfoAsync(
        // null,
        // "End Handle Request",
        // nameof(CreateEquipamentHandler),
        // response);

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
