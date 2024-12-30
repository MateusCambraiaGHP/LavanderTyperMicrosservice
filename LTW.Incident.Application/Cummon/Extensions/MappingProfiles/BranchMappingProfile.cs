using AutoMapper;
using LavanderTyperWeb.Application.Dtos.Branchs;
using LavanderTyperWeb.Application.Features.ViewModel.Branchs;
using LavanderTyperWeb.Domain.Primitives.Entities.Branchs;

namespace LTW.Incident.Application.Cummon.Extensions.MappingProfiles
{
  public class BranchMappingProfile : Profile
  {
    public BranchMappingProfile()
    {
      CreateMap<Branch, BranchViewModel>().ReverseMap();
      CreateMap<Branch, UpdateBranchDto>().ReverseMap();
    }
  }
}
