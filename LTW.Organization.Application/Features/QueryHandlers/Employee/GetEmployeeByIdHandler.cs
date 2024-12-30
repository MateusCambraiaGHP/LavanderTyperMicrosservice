using AutoMapper;
using FluentValidation.Results;
using LavanderTyperWeb.Core.Messages.CommonMessages;
using LavanderTyperWeb.Domain.Primitives.Common.Interfaces.Repositories;
using LavanderTyperWeb.Infrastructure.Loggers.Interfaces;
using LTW.Organization.Application.Features.Queries.Employees;
using LTW.Organization.Application.Features.Responses.Employees;
using LTW.Organization.Application.Features.ViewModel.Employees;

namespace LTW.Organization.Application.Features.QueryHandlers.Employee
{
  public class GetEmployeeByIdHandler : Handler<GetEmployeeByIdQuery, GetEmployeeByIdQueryResponse>
  {
    private readonly IEmployeeRepository _employeeRepository;
    private readonly ILoggerService _loggerService;

    public GetEmployeeByIdHandler(
        IEmployeeRepository employeeRepository,
        IMapper mapper,
        ILoggerService loggerService)
        : base(mapper)
    {
      _employeeRepository = employeeRepository;
      _loggerService = loggerService;
    }

    public override async Task<GetEmployeeByIdQueryResponse> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
    {
      try
      {
        await _loggerService.LogInfoAsync(
            request,
            "Start Handle Request",
            nameof(GetEmployeeByIdHandler));

        var currentEmployee = await _employeeRepository.GetAsync(ep => ep.Id == request.Id, null, null);
        var employeeMap = _mapper.Map<EmployeeViewModel>(currentEmployee.FirstOrDefault());

        var response = new GetEmployeeByIdQueryResponse(employeeMap);
        await _loggerService.LogInfoAsync(
            null,
            "End Handle Request",
            nameof(GetEmployeeByIdHandler),
            response);

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
