using LavanderTyperWeb.Core.Messages.CommonMessages;
using LTW.Organization.Application.Features.ViewModel.Employees;

namespace LTW.Organization.Application.Features.Responses.Employees
{
  public class CreateEmployeeCommandResponse : BaseHandlerResponse
  {
    public EmployeeViewModel Response { get; set; } = new();

    public CreateEmployeeCommandResponse() { }

    public CreateEmployeeCommandResponse(EmployeeViewModel response)
        : base() => Response = response;

    public CreateEmployeeCommandResponse(bool success, string message = "")
        : base(success, message) { }
  }
}
