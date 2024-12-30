using LavanderTyperWeb.Core.Messages.CommonMessages;
using LTW.Organization.Application.Dtos.Employee;
using LTW.Organization.Application.Features.Responses.Employees;

namespace LTW.Organization.Application.Features.Commands.Employee
{
  public class CreateEmployeeCommand : Command<CreateEmployeeCommandResponse>
  {
    public CreateEmployeeDto Request { get; init; }

    public CreateEmployeeCommand(CreateEmployeeDto request) => Request = request;
  }
}
