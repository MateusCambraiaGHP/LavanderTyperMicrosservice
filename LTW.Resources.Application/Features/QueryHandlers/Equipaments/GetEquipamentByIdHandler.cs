using AutoMapper;
using FluentValidation.Results;
using LavanderTyperWeb.Core.Messages.CommonMessages;
using LavanderTyperWeb.Domain.Primitives.Common.Interfaces.Repositories;
using LavanderTyperWeb.Infrastructure.Loggers.Interfaces;
using LTW.Resources.Application.Features.Queries.Equipaments;
using LTW.Resources.Application.Features.Responses.Equipaments;
using LTW.Resources.Application.Features.ViewModel.Equipaments;

namespace LTW.Resources.Application.Features.QueryHandlers.Equipaments
{
  public class GetEquipamentByIdHandler : Handler<GetEquipamentByIdQuery, GetEquipamentByIdQueryResponse>
  {
    private readonly IEquipamentRepository _equiapmentRepository;
    private readonly ILoggerService _loggerService;

    public GetEquipamentByIdHandler(
        IMapper mapper,
        ILoggerService loggerService,
        IEquipamentRepository equiapmentRepository)
        : base(mapper)
    {
      _loggerService = loggerService;
      _equiapmentRepository = equiapmentRepository;
    }

    public override async Task<GetEquipamentByIdQueryResponse> Handle(GetEquipamentByIdQuery request, CancellationToken cancellationToken)
    {
      try
      {
        await _loggerService.LogInfoAsync(
            request,
            "Start Handle Request",
            nameof(GetEquipamentByIdHandler));

        var currentEquipament = await _equiapmentRepository.GetAsync(ep => ep.Id == request.Id, null, null);
        var equipamentMap = _mapper.Map<EquipamentViewModel>(currentEquipament.FirstOrDefault());

        var response = new GetEquipamentByIdQueryResponse(equipamentMap);
        await _loggerService.LogInfoAsync(
            null,
            "End Handle Request",
            nameof(GetEquipamentByIdHandler),
            response);

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
