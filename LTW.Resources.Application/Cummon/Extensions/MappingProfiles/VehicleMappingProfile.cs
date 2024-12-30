using AutoMapper;
using LavanderTyperWeb.Domain.Primitives.Entities.Vehicles;
using LTW.Resources.Application.Dtos.Vehicles;
using LTW.Resources.Application.Features.ViewModel.Vehicles;

namespace LTW.Resources.Application.Cummon.Extensions.MappingProfiles
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
