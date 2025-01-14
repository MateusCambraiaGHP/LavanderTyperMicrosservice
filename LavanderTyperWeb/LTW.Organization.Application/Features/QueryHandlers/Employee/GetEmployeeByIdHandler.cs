using AutoMapper;
using FluentValidation.Results;
using LTW.Core.Messages.CommonMessages;
using LTW.Organization.Application.Features.Queries.Employees;
using LTW.Organization.Application.Features.Responses.Employees;
using LTW.Organization.Application.Features.ViewModel.Employees;
using LTW.Organization.Domain.Primitives.Common.Interfaces.Repositories;

namespace LTW.Organization.Application.Features.QueryHandlers.Employee
{
  public class GetEmployeeByIdHandler : Handler<GetEmployeeByIdQuery, GetEmployeeByIdQueryResponse>
  {
    private readonly IEmployeeRepository _employeeRepository;

    public GetEmployeeByIdHandler(
        IEmployeeRepository employeeRepository,
        IMapper mapper)
        : base(mapper)
    {
      _employeeRepository = employeeRepository;
    }

    public override async Task<GetEmployeeByIdQueryResponse> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
    {
      try
      {
        //await _loggerService.LogInfoAsync(
        //    request,
        //    "Start Handle Request",
        //    nameof(GetEmployeeByIdHandler));

        var currentEmployee = await _employeeRepository.GetAsync(ep => ep.Id == request.Id, null, null);
        var employeeMap = _mapper.Map<EmployeeViewModel>(currentEmployee.FirstOrDefault());

        var response = new GetEmployeeByIdQueryResponse(employeeMap);
        //await _loggerService.LogInfoAsync(
        //    null,
        //    "End Handle Request",
        //    nameof(GetEmployeeByIdHandler),
        //    response);

        return response;
      }
      catch (Exception ex)
      {
        return ResponseOnFailValidation(ex.Message, request.ValidationResult);
      }
    }

    public override List<ValidationFailure> Validate(GetEmployeeByIdQuery request)
    {
      throw new NotImplementedException();
    }
  }
}
