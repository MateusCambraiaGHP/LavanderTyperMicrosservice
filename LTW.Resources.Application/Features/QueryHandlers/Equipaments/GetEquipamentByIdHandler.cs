using AutoMapper;
using FluentValidation.Results;
using LTW.Core.Messages.CommonMessages;
using LTW.Resources.Application.Features.Queries.Equipaments;
using LTW.Resources.Application.Features.Responses.Equipaments;
using LTW.Resources.Application.Features.ViewModel.Equipaments;
using LTW.Resources.Domain.Primitives.Common.Interfaces.Repositories;

namespace LTW.Resources.Application.Features.QueryHandlers.Equipaments
{
  public class GetEquipamentByIdHandler : Handler<GetEquipamentByIdQuery, GetEquipamentByIdQueryResponse>
  {
    private readonly IEquipamentRepository _equiapmentRepository;

    public GetEquipamentByIdHandler(
        IMapper mapper,
        IEquipamentRepository equiapmentRepository)
        : base(mapper)
    {
      _equiapmentRepository = equiapmentRepository;
    }

    public override async Task<GetEquipamentByIdQueryResponse> Handle(GetEquipamentByIdQuery request, CancellationToken cancellationToken)
    {
      try
      {
        //await _loggerService.LogInfoAsync(
        //    request,
        //    "Start Handle Request",
        //    nameof(GetEquipamentByIdHandler));

        var currentEquipament = await _equiapmentRepository.GetAsync(ep => ep.Id == request.Id, null, null);
        var equipamentMap = _mapper.Map<EquipamentViewModel>(currentEquipament.FirstOrDefault());

        var response = new GetEquipamentByIdQueryResponse(equipamentMap);
        //await _loggerService.LogInfoAsync(
        //    null,
        //    "End Handle Request",
        //    nameof(GetEquipamentByIdHandler),
        //    response);

        return response;
      }
      catch (Exception ex)
      {
        return ResponseOnFailValidation(ex.Message, request.ValidationResult);
      }
    }

    public override List<ValidationFailure> Validate(GetEquipamentByIdQuery request)
    {
      throw new NotImplementedException();
    }
  }
}
