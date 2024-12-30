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
  public class GetEmployeeListHandler : Handler<GetEmployeeListQuery, GetEmployeeListQueryResponse>
  {
    private readonly IEmployeeRepository _employeeRepository;
    private readonly ILoggerService _loggerService;

    public GetEmployeeListHandler(
        IEmployeeRepository employeeRepository,
        IMapper mapper,
        ILoggerService loggerService)
        : base(mapper)
    {
      _employeeRepository = employeeRepository;
      _loggerService = loggerService;
    }

    public override async Task<GetEmployeeListQueryResponse> Handle(GetEmployeeListQuery request, CancellationToken cancellationToken)
    {
      try
      {
        await _loggerService.LogInfoAsync(
            request,
            "Start Handle Request",
            nameof(GetEmployeeListHandler));

        var listEmployee = await _employeeRepository.GetAsync(null, null, null);
        var listEmployeeMap = _mapper.Map<List<EmployeeViewModel>>(listEmployee);

        var response = new GetEmployeeListQueryResponse(listEmployeeMap);
        await _loggerService.LogInfoAsync(
            null,
            "End Handle Request",
            nameof(GetEmployeeListHandler),
            response);

        return response;
      }
      catch (Exception ex)
      {
        return ResponseOnFailValidation(ex.Message, request.ValidationResult);
      }
    }

    public override List<ValidationFailure> Validate(GetEmployeeListQuery request)
    {
      throw new NotImplementedException();
    }
  }
}
