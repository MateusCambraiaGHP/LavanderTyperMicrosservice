using AutoMapper;
using LavanderTyperWeb.Application.Dtos.Incidents;
using LavanderTyperWeb.Application.Features.ViewModel.Incidents;
using LavanderTyperWeb.Domain.Primitives.Entities.Incidents;

namespace LavanderTyperWeb.Application.Cummon.Extensions.MappingProfiles
{
    public class IncidentMappingProfile : Profile
    {
        public IncidentMappingProfile()
        {
            CreateMap<Incident, IncidentViewModel>().ReverseMap();
            CreateMap<Incident, UpdateIncidentDto>().ReverseMap();
        }
    }
}
