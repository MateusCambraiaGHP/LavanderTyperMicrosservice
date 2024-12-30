using AutoMapper;
using LavanderTyperWeb.Domain.Primitives.Entities.Incidents;
using LTW.Incident.Application.Dtos.Incidents;
using LTW.Incident.Application.Features.ViewModel.Incidents;

namespace LTW.Incident.Application.Cummon.Extensions.MappingProfiles
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
