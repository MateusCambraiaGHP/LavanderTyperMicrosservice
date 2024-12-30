using LavanderTyperWeb.Application.Features.ViewModel.Vehicles;
using LavanderTyperWeb.Core.Messages.CommonMessages;

namespace LavanderTyperWeb.Application.Features.Responses.Vehicles
{
    public class GetVehicleByIdQueryResponse : BaseHandlerResponse
    {
        public VehicleViewModel Employee { get; set; } = new();

        public GetVehicleByIdQueryResponse()
            : base() { }

        public GetVehicleByIdQueryResponse(VehicleViewModel employeeViewModel)
            : base("Employee created sucess") => Employee = employeeViewModel;

        public GetVehicleByIdQueryResponse(bool success, string message)
            : base(success, message) { }
    }
}
