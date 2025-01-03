using LTW.Core.Messages.CommonMessages;
using LTW.Organization.Application.Features.ViewModel.Employees;

namespace LTW.Organization.Application.Features.Responses.Employees
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
