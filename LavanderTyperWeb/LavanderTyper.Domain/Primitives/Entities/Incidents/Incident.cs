using LavanderTyperWeb.Core.DomainObjects;
using LavanderTyperWeb.Domain.Primitives.Entities.Branchs;
using LavanderTyperWeb.Domain.Primitives.Entities.Employees;
using LavanderTyperWeb.Domain.Primitives.Entities.Equipaments;
using LavanderTyperWeb.Domain.Primitives.Entities.Incidents.Enums;

namespace LavanderTyperWeb.Domain.Primitives.Entities.Incidents
{
    public class Incident : EntityBase
    {
        public Guid IdEmployee { get; set; }
        public Guid IdBranch { get; set; }
        public Guid IdEquipament { get; set; }
        public Employee Employee { get; set; } = new();
        public Equipament? Equipament { get; set; }
        public Branch Branch { get; set; } = new();
        public DateOnly Date { get; set; } = DateOnly.MinValue;
        public string Description { get; set; } = string.Empty;
        public IncidentType IncidentType { get; set; } = new();

        private Incident() { }

        public Incident(
            Guid idEmployee,
            Guid idBranch,
            Guid idEquipament,
            Employee employee,
            Equipament? equipament,
            Branch branch,
            DateOnly date,
            string description,
            IncidentType incidentType)
        {
            IdEmployee = idEmployee;
            IdBranch = idBranch;
            IdEquipament = idEquipament;
            Employee = employee;
            Equipament = equipament;
            Branch = branch;
            Date = date;
            Description = description;
            IncidentType = incidentType;
        }
    }
}
