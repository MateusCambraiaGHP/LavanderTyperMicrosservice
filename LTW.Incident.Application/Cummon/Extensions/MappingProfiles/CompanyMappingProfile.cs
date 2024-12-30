using AutoMapper;
using LavanderTyperWeb.Application.Dtos.Companies;
using LavanderTyperWeb.Application.Features.ViewModel.Companies;
using LavanderTyperWeb.Domain.Primitives.Entities.Companies;

namespace LTW.Incident.Application.Cummon.Extensions.MappingProfiles
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
