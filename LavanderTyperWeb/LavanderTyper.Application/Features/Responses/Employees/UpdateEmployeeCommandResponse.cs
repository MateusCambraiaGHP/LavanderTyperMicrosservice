using LavanderTyperWeb.Application.Features.ViewModel.Employees;
using LavanderTyperWeb.Core.Messages.CommonMessages;

namespace LavanderTyperWeb.Application.Features.Responses.Employees
{
    public class UpdateEmployeeCommandResponse : BaseHandlerResponse
    {
        public EmployeeViewModel Response { get; set; } = new();

        public UpdateEmployeeCommandResponse() { }

        public UpdateEmployeeCommandResponse(EmployeeViewModel response)
            : base() => Response = response;

        public UpdateEmployeeCommandResponse(bool success, string message = "")
            : base(success, message) { }
    }
}
