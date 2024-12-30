using AutoMapper;
using LavanderTyperWeb.Domain.Primitives.Entities.Employees;
using LTW.Organization.Application.Dtos.Branchs;
using LTW.Organization.Application.Features.ViewModel.Employees;

namespace LTW.Organization.Application.Cummon.Extensions.MappingProfiles
{
  public class EmployeeMappingProfile : Profile
  {
    public EmployeeMappingProfile()
    {
      CreateMap<Employee, EmployeeViewModel>().ReverseMap();
      CreateMap<Employee, UpdateBranchDto>().ReverseMap();
    }
  }
}
