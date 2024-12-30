using LavanderTyperWeb.Application.Features.ViewModel.Vehicles;
using LavanderTyperWeb.Core.Messages.CommonMessages;
using LTW.Organization.Application.Features.ViewModel.Employees;

namespace LTW.Organization.Application.Features.Responses.Employees
{
  public class GetEmployeeListQueryResponse : BaseHandlerResponse
  {
    public List<EmployeeViewModel> Response { get; set; } = new();

    public GetEmployeeListQueryResponse()
        : base() { }

    public GetEmployeeListQueryResponse(List<EmployeeViewModel> response)
        : base() => Response = response;

    public GetEmployeeListQueryResponse(bool success, string message)
        : base(success, message) { }
  }
}
