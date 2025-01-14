using AutoMapper;
using FluentValidation.Results;
using LTW.Core.Messages.CommonMessages;
using LTW.Organization.Application.Features.Queries.Branchs;
using LTW.Organization.Application.Features.Responses.Branchs;
using LTW.Organization.Application.Features.ViewModel.Branchs;
using LTW.Organization.Domain.Primitives.Common.Interfaces.Repositories;

namespace LTW.Organization.Application.Features.QueryHandlers.Branchs
{
  public class GetBranchByIdHandler : Handler<GetBranchByIdQuery, GetBranchByIdQueryResponse>
  {
    private readonly IBranchRepository _branchRepository;

    public GetBranchByIdHandler(
        IMapper mapper,
        IBranchRepository branchRepository)
        : base(mapper)
    {
      _branchRepository = branchRepository;
    }

    public override async Task<GetBranchByIdQueryResponse> Handle(GetBranchByIdQuery request, CancellationToken cancellationToken)
    {
      try
      {
        //await _loggerService.LogInfoAsync(
        //    request,
        //    "Start Handle Request",
        //    nameof(GetBranchByIdHandler));

        var currentBranch = await _branchRepository.GetAsync(ep => ep.Id == request.Id, null, null);
        var branchMap = _mapper.Map<BranchViewModel>(currentBranch.FirstOrDefault());

        var response = new GetBranchByIdQueryResponse(branchMap);
        //await _loggerService.LogInfoAsync(
        //    null,
        //    "End Handle Request",
        //    nameof(GetBranchByIdHandler),
        //    response);

        return response;
      }
      catch (Exception ex)
      {
        return ResponseOnFailValidation(ex.Message, request.ValidationResult);
      }
    }

    public override List<ValidationFailure> Validate(GetBranchByIdQuery request)
    {
      throw new NotImplementedException();
    }
  }
}
