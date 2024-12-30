using AutoMapper;
using FluentValidation.Results;
using LavanderTyperWeb.Application.Features.Queries.Branchs;
using LavanderTyperWeb.Application.Features.Responses.Branchs;
using LavanderTyperWeb.Application.Features.ViewModel.Branchs;
using LavanderTyperWeb.Core.Messages.CommonMessages;
using LavanderTyperWeb.Domain.Primitives.Common.Interfaces.Repositories;
using LavanderTyperWeb.Infrastructure.Loggers.Interfaces;

namespace LavanderTyperWeb.Application.Features.QueryHandlers.Branchs
{
    public class GetBranchListHandler : Handler<GetBranchListQuery, GetBranchListQueryResponse>
    {
        private readonly IBranchRepository _branchRepository;
        private readonly ILoggerService _loggerService;

        public GetBranchListHandler(
            IBranchRepository branchRepository,
            IMapper mapper,
            ILoggerService loggerService)
            : base(mapper)
        {
            _branchRepository = branchRepository;
            _loggerService = loggerService;
        }

        public override async Task<GetBranchListQueryResponse> Handle(GetBranchListQuery request, CancellationToken cancellationToken)
        {
            try
            {
                await _loggerService.LogInfoAsync(
                    request,
                    "Start Handle Request",
                    nameof(GetBranchListHandler));

                var branchList = await _branchRepository.GetAsync(null, null, null);
                var branchListMap = _mapper.Map<List<BranchViewModel>>(branchList);

                var response = new GetBranchListQueryResponse(branchListMap);
                await _loggerService.LogInfoAsync(
                    null,
                    "End Handle Request",
                    nameof(GetBranchListHandler),
                    response);

                return response;
            }
            catch (Exception ex)
            {
                return ResponseOnFailValidation(ex.Message, request.ValidationResult);
            }
        }

        public override List<ValidationFailure> Validate(GetBranchListQuery request)
        {
            throw new NotImplementedException();
        }
    }
}
