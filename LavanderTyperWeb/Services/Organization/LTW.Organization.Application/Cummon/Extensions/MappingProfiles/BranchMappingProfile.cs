using AutoMapper;
using LTW.Organization.Application.Dtos.Branchs;
using LTW.Organization.Application.Features.ViewModel.Branchs;
using LTW.Organization.Domain.Primitives.Entities.Branchs;

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
