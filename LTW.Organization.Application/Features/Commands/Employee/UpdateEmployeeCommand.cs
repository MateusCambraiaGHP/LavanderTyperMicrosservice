using LavanderTyperWeb.Core.Messages.CommonMessages;
using LTW.Organization.Application.Dtos.Employee;
using LTW.Organization.Application.Features.Responses.Employees;

namespace LTW.Organization.Application.Features.Commands.Employee
{
  public class UpdateEmployeeCommand : Command<UpdateEmployeeCommandResponse>
  {
    public UpdateEmployeeDto Request { get; init; }

    public UpdateEmployeeCommand(UpdateEmployeeDto request) => Request = request;
  }
}
