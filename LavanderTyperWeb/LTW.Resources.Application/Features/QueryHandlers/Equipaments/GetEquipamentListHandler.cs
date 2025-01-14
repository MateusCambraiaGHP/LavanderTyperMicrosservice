﻿using AutoMapper;
using FluentValidation.Results;
using LTW.Core.Messages.CommonMessages;
using LTW.Resources.Application.Features.Queries.Equipaments;
using LTW.Resources.Application.Features.Responses.Equipaments;
using LTW.Resources.Application.Features.ViewModel.Equipaments;
using LTW.Resources.Domain.Primitives.Common.Interfaces.Repositories;

namespace LTW.Resources.Application.Features.QueryHandlers.Equipaments
{
  public class GetEquipamentListHandler : Handler<GetEquipamentListQuery, GetEquipamentListQueryResponse>
  {
    private readonly IEquipamentRepository _equipamentRepository;

    public GetEquipamentListHandler(
        IMapper mapper,
        IEquipamentRepository equipamentRepository)
        : base(mapper)
    {
      _equipamentRepository = equipamentRepository;
    }

    public override async Task<GetEquipamentListQueryResponse> Handle(GetEquipamentListQuery request, CancellationToken cancellationToken)
    {
      try
      {
        //await _loggerService.LogInfoAsync(
        //    request,
        //    "Start Handle Request",
        //    nameof(GetEquipamentListHandler));

        var equipamentList = await _equipamentRepository.GetAsync(null, null, null);
        var equipamentListMap = _mapper.Map<List<EquipamentViewModel>>(equipamentList);

        var response = new GetEquipamentListQueryResponse(equipamentListMap);
        //await _loggerService.LogInfoAsync(
        //    null,
        //    "End Handle Request",
        //    nameof(GetEquipamentListHandler),
        //    response);

        return response;
      }
      catch (Exception ex)
      {
        return ResponseOnFailValidation(ex.Message, request.ValidationResult);
      }
    }

    public override List<ValidationFailure> Validate(GetEquipamentListQuery request)
    {
      throw new NotImplementedException();
    }
  }
}
