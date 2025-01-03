using AutoMapper;
using LTW.Resources.Application.Dtos.Equipaments;
using LTW.Resources.Application.Features.ViewModel.Equipaments;
using LTW.Resources.Domain.Primitives.Entities.Equipaments;

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
