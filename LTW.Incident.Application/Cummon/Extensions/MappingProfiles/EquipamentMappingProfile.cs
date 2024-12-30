using AutoMapper;
using LavanderTyperWeb.Application.Dtos.Equipaments;
using LavanderTyperWeb.Application.Features.ViewModel.Equipaments;
using LavanderTyperWeb.Domain.Primitives.Entities.Equipaments;

namespace LTW.Incident.Application.Cummon.Extensions.MappingProfiles
{
  public class EquipamentMappingProfile : Profile
  {
    public EquipamentMappingProfile()
    {
      CreateMap<Equipament, EquipamentViewModel>().ReverseMap();
      CreateMap<Equipament, UpdateEquipamentDto>().ReverseMap();
    }
  }
}
