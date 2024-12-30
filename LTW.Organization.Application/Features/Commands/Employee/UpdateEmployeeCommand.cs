using LavanderTyperWeb.Application.Dtos.Employee;
using LavanderTyperWeb.Application.Features.Responses.Employees;
using LavanderTyperWeb.Core.Messages.CommonMessages;

namespace LavanderTyperWeb.Application.Features.Commands.Employee
{
    public class UpdateEmployeeCommand : Command<UpdateEmployeeCommandResponse>
    {
        public UpdateEmployeeDto Request { get; init; }

        public UpdateEmployeeCommand(UpdateEmployeeDto request) => Request = request;
    }
}
