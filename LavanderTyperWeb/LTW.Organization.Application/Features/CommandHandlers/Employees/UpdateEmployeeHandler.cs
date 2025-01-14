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
  public class UpdateEmployeeHandler : Handler<UpdateEmployeeCommand, UpdateEmployeeCommandResponse>
  {
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateEmployeeHandler(
        IEmployeeRepository employeeRepository,
        IUnitOfWork unitOfWork,
        IMapper mapper)
        : base(mapper)
    {
      _employeeRepository = employeeRepository;
      _unitOfWork = unitOfWork;
    }

    public override async Task<UpdateEmployeeCommandResponse> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
    {
      try
      {
        //await _loggerService.LogInfoAsync(request,
        //    "Start Handle Request",
        //    nameof(UpdateEmployeeHandler));
        request.ValidationResult = Validate(request);

        if (!request.IsValid())
          return ResponseOnFailValidation("fail on update employee", request.ValidationResult);

        Employee employeeMap = _mapper.Map<Employee>(request.Request);
        await _employeeRepository.Update(employeeMap);
        await _unitOfWork.CommitChangesAsync();
        var employeeViewModel = _mapper.Map<EmployeeViewModel>(employeeMap);

        var response = new UpdateEmployeeCommandResponse(employeeViewModel);
        //await _loggerService.LogInfoAsync(null,
        //    "End Handle Request",
        //    nameof(UpdateEmployeeHandler),
        //    response);

        return response;
      }
      catch (Exception ex)
      {
        return ResponseOnFailValidation(ex.Message, request.ValidationResult);
      }
    }

    public override List<ValidationFailure> Validate(UpdateEmployeeCommand request)
    {
      var erros = new UpdateEmployeeCommandValidation().Validate(request);
      return erros.Errors;
    }
  }
}
