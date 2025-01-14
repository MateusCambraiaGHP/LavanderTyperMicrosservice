using AutoMapper;
using LTW.Organization.Application.Dtos.Companies;
using LTW.Organization.Application.Features.ViewModel.Companies;
using LTW.Organization.Domain.Primitives.Entities.Companies;

namespace LTW.Organization.Application.Cummon.Extensions.MappingProfiles
{
  public class CompanyMappingProfile : Profile
  {
    public CompanyMappingProfile()
    {
      CreateMap<Company, CompanyViewModel>().ReverseMap();
      CreateMap<Company, UpdateCompanyDto>().ReverseMap();
    }
  }
}
