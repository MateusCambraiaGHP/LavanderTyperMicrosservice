using AutoMapper;
using LavanderTyperWeb.Application.Dtos.Branchs;
using LavanderTyperWeb.Application.Features.ViewModel.Employees;
using LavanderTyperWeb.Domain.Primitives.Entities.Employees;

namespace LavanderTyperWeb.Application.Cummon.Extensions.MappingProfiles
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
