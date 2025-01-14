using AutoMapper;
using FluentValidation.Results;
using LTW.Core.Messages.CommonMessages;
using LTW.Organization.Application.Features.Queries.Branchs;
using LTW.Organization.Application.Features.Responses.Branchs;
using LTW.Organization.Application.Features.ViewModel.Branchs;
using LTW.Organization.Domain.Primitives.Common.Interfaces.Repositories;

namespace LTW.Organization.Application.Features.QueryHandlers.Branchs
{
  public class GetBranchListHandler : Handler<GetBranchListQuery, GetBranchListQueryResponse>
  {
    private readonly IBranchRepository _branchRepository;

    public GetBranchListHandler(
        IBranchRepository branchRepository,
        IMapper mapper)
        : base(mapper)
    {
      _branchRepository = branchRepository;
    }

    public override async Task<GetBranchListQueryResponse> Handle(GetBranchListQuery request, CancellationToken cancellationToken)
    {
      try
      {
        //await _loggerService.LogInfoAsync(
        //    request,
        //    "Start Handle Request",
        //    nameof(GetBranchListHandler));

        var branchList = await _branchRepository.GetAsync(null, null, null);
        var branchListMap = _mapper.Map<List<BranchViewModel>>(branchList);

        var response = new GetBranchListQueryResponse(branchListMap);
        //await _loggerService.LogInfoAsync(
        //    null,
        //    "End Handle Request",
        //    nameof(GetBranchListHandler),
        //    response);

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
