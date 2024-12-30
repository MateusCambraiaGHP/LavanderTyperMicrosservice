using LavanderTyperWeb.Application.Features.ViewModel.Employees;
using LavanderTyperWeb.Core.Messages.CommonMessages;

namespace LavanderTyperWeb.Application.Features.Responses.Employees
{
    public class GetEmployeeByIdQueryResponse : BaseHandlerResponse
    {
        public EmployeeViewModel Response { get; set; } = new();

        public GetEmployeeByIdQueryResponse()
            : base() { }

        public GetEmployeeByIdQueryResponse(EmployeeViewModel response)
            : base("Employee created sucess") => Response = response;

        public GetEmployeeByIdQueryResponse(bool success, string message)
            : base(success, message) { }
    }
}
