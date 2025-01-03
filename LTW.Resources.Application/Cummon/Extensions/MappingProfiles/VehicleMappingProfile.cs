using AutoMapper;
using LTW.Resources.Application.Dtos.Vehicles;
using LTW.Resources.Application.Features.ViewModel.Vehicles;
using LTW.Resources.Domain.Primitives.Entities.Vehicles;

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
