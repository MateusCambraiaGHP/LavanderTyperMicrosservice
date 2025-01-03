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
  public class UpdateEquipamentHandler : Handler<UpdateEquipamentCommand, UpdateEquipamentCommandResponse>
  {
    private readonly IEquipamentRepository _equipamentRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateEquipamentHandler(
        IEquipamentRepository equipamentRepository,
        IUnitOfWork unitOfWork,
        IMapper mapper)
        : base(mapper)
    {
      _equipamentRepository = equipamentRepository;
      _unitOfWork = unitOfWork;
    }

    public override async Task<UpdateEquipamentCommandResponse> Handle(UpdateEquipamentCommand request, CancellationToken cancellationToken)
    {
      try
      {
        request.ValidationResult = Validate(request);

        if (!request.IsValid())
          return ResponseOnFailValidation("fail on update employee", request.ValidationResult);

        var equipamentMap = _mapper.Map<Equipament>(request.Request);
        await _equipamentRepository.Update(equipamentMap);
        await _unitOfWork.CommitChangesAsync();

        var equipamentViewModel = _mapper.Map<EquipamentViewModel>(equipamentMap);
        var response = new UpdateEquipamentCommandResponse(equipamentViewModel);

        return response;
      }
      catch (Exception ex)
      {
        return ResponseOnFailValidation(ex.Message, request.ValidationResult);
      }
    }

    public override List<ValidationFailure> Validate(UpdateEquipamentCommand request)
    {
      var erros = new UpdateEquipamentCommandValidation().Validate(request);
      return erros.Errors;
    }
  }
}
