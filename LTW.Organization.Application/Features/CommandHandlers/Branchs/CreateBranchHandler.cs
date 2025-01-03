using AutoMapper;
using FluentValidation.Results;
using LTW.Core.Data;
using LTW.Core.Messages.CommonMessages;
using LTW.Organization.Application.Features.Commands.Branchs;
using LTW.Organization.Application.Features.Responses.Branchs;
using LTW.Organization.Application.Features.Validations.Branchs;
using LTW.Organization.Application.Features.ViewModel.Branchs;
using LTW.Organization.Domain.Primitives.Common.Interfaces.Repositories;
using LTW.Organization.Domain.Primitives.Entities.Branchs;

namespace LTW.Organization.Application.Features.CommandHandlers.Branchs
{
  public class CreateBranchHandler : Handler<CreateBranchCommand, CreateBranchCommandResponse>
  {
    private readonly IBranchRepository _branchRepository;
    private readonly ICompanyRepository _companyRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateBranchHandler(
        IBranchRepository branchRepository,
        IMapper mapper,
        IUnitOfWork unitOfWork,
        ICompanyRepository companyRepository)
        : base(mapper)
    {
      _branchRepository = branchRepository;
      _unitOfWork = unitOfWork;
      _companyRepository = companyRepository;
    }

    public override async Task<CreateBranchCommandResponse> Handle(CreateBranchCommand request, CancellationToken cancellationToken)
    {
      try
      {
        //await _loggerService.LogInfoAsync(
        //    request,
        //    "Start Handle Request",
        //    nameof(CreateBranchHandler));
        request.ValidationResult = Validate(request);

        if (!request.IsValid())
          return ResponseOnFailValidation("fail on create branch", request.ValidationResult);

        var currentCompany = await _companyRepository.GetAsync(ep => ep.Id == request.Request.IdCompany, null, null);
        var branch = new Branch(
            request.Request.IdCompany,
            request.Request.Name,
            request.Request.Address,
            currentCompany.First(),
            new());
        await _branchRepository.Create(branch);
        await _unitOfWork.CommitChangesAsync();

        var branchViewModel = _mapper.Map<BranchViewModel>(branch);
        var response = new CreateBranchCommandResponse(branchViewModel);

        //await _loggerService.LogInfoAsync(
        // null,
        // "End Handle Request",
        // nameof(CreateBranchHandler),
        // response);

        return response;
      }
      catch (Exception ex)
      {
        return ResponseOnFailValidation(ex.Message, request.ValidationResult);
      }
    }

    public override List<ValidationFailure> Validate(CreateBranchCommand request)
    {
      var validate = new CreateBranchCommandValidation().Validate(request);
      return validate.Errors;
    }
  }
}
