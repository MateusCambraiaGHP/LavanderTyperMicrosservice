using AutoMapper;
using LavanderTyperWeb.Domain.Primitives.Entities.Equipaments;
using LTW.Resources.Application.Dtos.Equipaments;
using LTW.Resources.Application.Features.ViewModel.Equipaments;

namespace LTW.Resources.Application.Cummon.Extensions.MappingProfiles
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
