using LTW.Core.Messages.CommonMessages;
using LTW.Resources.Application.Features.ViewModel.Vehicles;

namespace LTW.Resources.Application.Features.Responses.Vehicles
{
  public class GetVehicleListQueryResponse : BaseHandlerResponse
  {
    public List<VehicleViewModel> Employees { get; set; } = new();

    public GetVehicleListQueryResponse()
        : base() { }

    public GetVehicleListQueryResponse(List<VehicleViewModel> employeeListViewModel)
        : base() => Employees = employeeListViewModel;

    public GetVehicleListQueryResponse(bool success, string message)
        : base(success, message) { }
  }
}
