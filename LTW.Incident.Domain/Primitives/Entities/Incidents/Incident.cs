using LavanderTyperWeb.Core.DomainObjects;
using LTW.Incident.Domain.Primitives.Entities.Incidents.Enums;

namespace LTW.Incident.Domain.Primitives.Entities.Incidents
{
  public class Incident : EntityBase
  {
    public Guid IdEmployee { get; set; }
    public Guid IdBranch { get; set; }
    public Guid IdEquipament { get; set; }
    public DateOnly Date { get; set; } = DateOnly.MinValue;
    public string Description { get; set; } = string.Empty;
    public IncidentType IncidentType { get; set; } = new();

    private Incident() { }

    public Incident(
        Guid idEmployee,
        Guid idBranch,
        Guid idEquipament,
        DateOnly date,
        string description,
        IncidentType incidentType)
    {
      IdEmployee = idEmployee;
      IdBranch = idBranch;
      IdEquipament = idEquipament;
      Date = date;
      Description = description;
      IncidentType = incidentType;
    }
  }
}
