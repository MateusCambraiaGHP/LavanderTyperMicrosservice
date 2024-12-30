using LavanderTyperWeb.Application.Dtos.Branchs;
using LavanderTyperWeb.Application.Dtos.Employee;
using LavanderTyperWeb.Domain.Primitives.Entities.Equipaments;
using LavanderTyperWeb.Domain.Primitives.Entities.Incidents.Enums;

namespace LTW.Incident.Application.Dtos.Incidents
{
  public class UpdateIncidentDto
  {
    public Guid IdEmployee { get; set; }
    public Guid IdBranch { get; set; }
    public Guid IdEquipament { get; set; }
    public CreateEmployeeDto Employee { get; set; } = new();
    public Equipament? Equipament { get; set; }
    public CreateBranchDto Branch { get; set; } = new();
    public DateOnly Date { get; set; } = DateOnly.MinValue;
    public string Description { get; set; } = string.Empty;
    public IncidentType IncidentType { get; set; } = new();
  }
}
