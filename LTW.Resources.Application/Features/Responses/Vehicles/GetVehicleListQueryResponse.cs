using LavanderTyperWeb.Application.Features.ViewModel.Vehicles;
using LavanderTyperWeb.Core.Messages.CommonMessages;

namespace LavanderTyperWeb.Application.Features.Responses.Vehicles
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
