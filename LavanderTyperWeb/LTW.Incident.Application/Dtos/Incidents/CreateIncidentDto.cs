using LTW.Incident.Domain.Primitives.Entities.Incidents.Enums;

namespace LTW.Incident.Application.Dtos.Incidents
{
  public class CreateIncidentDto
  {
    public Guid IdEmployee { get; set; }
    public Guid IdBranch { get; set; }
    public Guid IdEquipament { get; set; }
    public DateOnly Date { get; set; } = DateOnly.MinValue;
    public string Description { get; set; } = string.Empty;
    public IncidentType IncidentType { get; set; } = new();
  }
}
