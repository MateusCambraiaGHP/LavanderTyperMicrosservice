using LavanderTyperWeb.Application.Dtos.Employee;
using LavanderTyperWeb.Application.Features.Responses.Employees;
using LavanderTyperWeb.Core.Messages.CommonMessages;

namespace LavanderTyperWeb.Application.Features.Commands.Employee
{
    public class CreateEmployeeCommand : Command<CreateEmployeeCommandResponse>
    {
        public CreateEmployeeDto Request { get; init; }

        public CreateEmployeeCommand(CreateEmployeeDto request) => Request = request;
    }
}
