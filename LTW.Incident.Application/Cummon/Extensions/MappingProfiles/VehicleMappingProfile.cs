using AutoMapper;
using LavanderTyperWeb.Application.Dtos.Vehicles;
using LavanderTyperWeb.Application.Features.ViewModel.Vehicles;
using LavanderTyperWeb.Domain.Primitives.Entities.Vehicles;

namespace LTW.Incident.Application.Cummon.Extensions.MappingProfiles
{
  public class VehicleMappingProfile : Profile
  {
    public VehicleMappingProfile()
    {
      CreateMap<Vehicle, VehicleViewModel>().ReverseMap();
      CreateMap<Vehicle, UpdateVehicleDto>().ReverseMap();
    }
  }
}
