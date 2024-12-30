using AutoMapper;
using LavanderTyperWeb.Domain.Primitives.Entities.Branchs;
using LTW.Organization.Application.Dtos.Branchs;
using LTW.Organization.Application.Features.ViewModel.Branchs;

namespace LTW.Organization.Application.Cummon.Extensions.MappingProfiles
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
