using AutoMapper;
using FluentValidation.Results;
using LavanderTyperWeb.Application.Features.Validations.Branchs;
using LavanderTyperWeb.Core.Data;
using LavanderTyperWeb.Core.Messages.CommonMessages;
using LavanderTyperWeb.Domain.Primitives.Common.Interfaces.Repositories;
using LavanderTyperWeb.Domain.Primitives.Entities.Branchs;
using LavanderTyperWeb.Infrastructure.Loggers.Interfaces;
using LTW.Organization.Application.Features.Commands.Branchs;
using LTW.Organization.Application.Features.Responses.Branchs;
using LTW.Organization.Application.Features.ViewModel.Branchs;

namespace LTW.Organization.Application.Features.CommandHandlers.Branchs
{
  public class UpdateBranchHandler : Handler<UpdateBranchCommand, UpdateBranchCommandResponse>
  {
    private readonly IBranchRepository _branchRepository;
    private readonly ICompanyRepository _companyRepository;
    private readonly ILoggerService _loggerService;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateBranchHandler(
        IBranchRepository branchRepository,
        IUnitOfWork unitOfWork,
        IMapper mapper,
        ILoggerService loggerService,
        ICompanyRepository companyRepository)
        : base(mapper)
    {
      _branchRepository = branchRepository;
      _unitOfWork = unitOfWork;
      _loggerService = loggerService;
      _companyRepository = companyRepository;
    }

    public override async Task<UpdateBranchCommandResponse> Handle(UpdateBranchCommand request, CancellationToken cancellationToken)
    {
      try
      {
        await _loggerService.LogInfoAsync(request,
            "Start Handle Request",
            nameof(UpdateBranchHandler));
        request.ValidationResult = Validate(request);

        if (!request.IsValid())
          return ResponseOnFailValidation("fail on update branch", request.ValidationResult);

        Branch branchMap = _mapper.Map<Branch>(request.Request);
        await _branchRepository.Update(branchMap);
        await _unitOfWork.CommitChangesAsync();
        var branchViewModel = _mapper.Map<BranchViewModel>(branchMap);

        var response = new UpdateBranchCommandResponse(branchViewModel);
        await _loggerService.LogInfoAsync(null,
            "End Handle Request",
            nameof(UpdateBranchHandler),
            response);

        return response;
      }
      catch (Exception ex)
      {
        return ResponseOnFailValidation(ex.Message, request.ValidationResult);
      }
    }

    public override List<ValidationFailure> Validate(UpdateBranchCommand request)
    {
      var erros = new UpdateBranchCommandValidation().Validate(request);
      return erros.Errors;
    }
  }
}
