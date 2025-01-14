using AutoMapper;
using FluentValidation.Results;
using LTW.Core.Data;
using LTW.Core.Messages.CommonMessages;
using LTW.Organization.Application.Features.Commands.Employee;
using LTW.Organization.Application.Features.Responses.Employees;
using LTW.Organization.Application.Features.Validations.Employees;
using LTW.Organization.Application.Features.ViewModel.Employees;
using LTW.Organization.Domain.Primitives.Common.Interfaces.Repositories;
using LTW.Organization.Domain.Primitives.Entities.Employees;

namespace LTW.Organization.Application.Features.CommandHandlers.Employees
{
  public class CreateEmployeeHandler : Handler<CreateEmployeeCommand, CreateEmployeeCommandResponse>
  {
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IBranchRepository _branchRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateEmployeeHandler(
        IEmployeeRepository employeeRepository,
        IMapper mapper,
        IUnitOfWork unitOfWork,
        IBranchRepository branchRepository)
        : base(mapper)
    {
      _employeeRepository = employeeRepository;
      _unitOfWork = unitOfWork;
      _branchRepository = branchRepository;
    }

    public override async Task<CreateEmployeeCommandResponse> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
      try
      {
        //await _loggerService.LogInfoAsync(
        //    request,
        //    "Start Handle Request",
        //    nameof(CreateEmployeeHandler));
        request.ValidationResult = Validate(request);

        if (!request.IsValid())
          return ResponseOnFailValidation("fail on create employee", request.ValidationResult);

        var branches = await _branchRepository.GetAsync(null, null, null);
        var matchingBranches = branches.Where(bc => request.Request.IdsBranch.Contains(bc.Id)).ToList();
        var employee = new Employee(
            request.Request.FirstName,
            request.Request.LastName,
            request.Request.Address,
            request.Request.Number,
            request.Request.City,
            request.Request.Complements,
            request.Request.LicenseNumber,
            request.Request.SalaryPerHour,
            request.Request.Salary,
            matchingBranches);
        await _employeeRepository.Create(employee);
        await _unitOfWork.CommitChangesAsync();

        var employeeViewModel = _mapper.Map<EmployeeViewModel>(employee);
        var response = new CreateEmployeeCommandResponse(employeeViewModel);

        //await _loggerService.LogInfoAsync(
        // null,
        // "End Handle Request",
        // nameof(CreateEmployeeHandler),
        // response);

        return response;
      }
      catch (Exception ex)
      {
        return ResponseOnFailValidation(ex.Message, request.ValidationResult);
      }
    }

    public override List<ValidationFailure> Validate(CreateEmployeeCommand request)
    {
      var validate = new CreateEmployeeCommandValidation().Validate(request);
      return validate.Errors;
    }
  }
}
