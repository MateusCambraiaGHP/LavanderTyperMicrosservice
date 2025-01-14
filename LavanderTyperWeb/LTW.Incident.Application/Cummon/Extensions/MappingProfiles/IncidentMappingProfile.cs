using AutoMapper;
using LTW.Incident.Application.Dtos.Incidents;
using LTW.Incident.Application.Features.ViewModel.Incidents;
using IncidentEntity = LTW.Incident.Domain.Primitives.Entities.Incidents.Incident;

namespace LTW.Incident.Application.Cummon.Extensions.MappingProfiles
{
  public class IncidentMappingProfile : Profile
  {
    public IncidentMappingProfile()
    {
      CreateMap<IncidentEntity, IncidentViewModel>().ReverseMap();
      CreateMap<IncidentEntity, UpdateIncidentDto>().ReverseMap();
    }
  }
}
