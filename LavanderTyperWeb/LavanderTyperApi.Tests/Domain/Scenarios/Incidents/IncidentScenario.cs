using LavanderTyperWeb.Domain.Primitives.Entities.Branchs;
using LavanderTyperWeb.Domain.Primitives.Entities.Employees;
using LavanderTyperWeb.Domain.Primitives.Entities.Equipaments;
using LavanderTyperWeb.Domain.Primitives.Entities.Incidents;
using LavanderTyperWeb.Domain.Primitives.Entities.Incidents.Enums;
using LavanderTyperWeb.Tests.Domain.Scenarios.Common;

namespace LavanderTyperWeb.Tests.Domain.Scenarios.Incidents
{
    public class IncidentScenario : Scenario
    {
        public Guid IdEmployee { get; set; }
        public Guid IdBranch { get; set; }
        public Guid IdEquipament { get; set; }
        public Employee Employee { get; set; }
        public Equipament? Equipament { get; set; }
        public Branch Branch { get; set; }
        public DateOnly Date { get; set; }
        public string Description { get; set; }
        public IncidentType IncidentType { get; set; }
        public bool ExpectedIsValid { get; set; }

        public Incident ToIncident()
        {
            return new Incident(
                IdEmployee,
                IdBranch,
                IdEquipament,
                Employee,
                Equipament,
                Branch,
                Date,
                Description,
                IncidentType);
        }
    }
}
