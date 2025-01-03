using AutoMapper;
using LTW.Organization.Application.Dtos.Branchs;
using LTW.Organization.Application.Features.ViewModel.Employees;
using LTW.Organization.Domain.Primitives.Entities.Employees;

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
