using AutoMapper;
using FluentValidation.Results;
using LavanderTyperWeb.Application.Features.Queries.Equipaments;
using LavanderTyperWeb.Application.Features.Responses.Equipaments;
using LavanderTyperWeb.Application.Features.ViewModel.Equipaments;
using LavanderTyperWeb.Core.Messages.CommonMessages;
using LavanderTyperWeb.Domain.Primitives.Common.Interfaces.Repositories;
using LavanderTyperWeb.Infrastructure.Loggers.Interfaces;

namespace LavanderTyperWeb.Application.Features.QueryHandlers.Equipaments
{
    public class GetEquipamentListHandler : Handler<GetEquipamentListQuery, GetEquipamentListQueryResponse>
    {
        private readonly IEquipamentRepository _equipamentRepository;
        private readonly ILoggerService _loggerService;

        public GetEquipamentListHandler(
            IMapper mapper,
            ILoggerService loggerService,
            IEquipamentRepository equipamentRepository)
            : base(mapper)
        {
            _loggerService = loggerService;
            _equipamentRepository = equipamentRepository;
        }

        public override async Task<GetEquipamentListQueryResponse> Handle(GetEquipamentListQuery request, CancellationToken cancellationToken)
        {
            try
            {
                await _loggerService.LogInfoAsync(
                    request,
                    "Start Handle Request",
                    nameof(GetEquipamentListHandler));

                var equipamentList = await _equipamentRepository.GetAsync(null, null, null);
                var equipamentListMap = _mapper.Map<List<EquipamentViewModel>>(equipamentList);

                var response = new GetEquipamentListQueryResponse(equipamentListMap);
                await _loggerService.LogInfoAsync(
                    null,
                    "End Handle Request",
                    nameof(GetEquipamentListHandler),
                    response);

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
