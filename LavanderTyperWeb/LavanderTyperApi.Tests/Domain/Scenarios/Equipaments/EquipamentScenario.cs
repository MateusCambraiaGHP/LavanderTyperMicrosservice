using LavanderTyperWeb.Domain.Primitives.Entities.Branchs;
using LavanderTyperWeb.Domain.Primitives.Entities.Companies;
using LavanderTyperWeb.Domain.Primitives.Entities.Employees;
using LavanderTyperWeb.Domain.Primitives.Entities.Equipaments;
using LavanderTyperWeb.Tests.Domain.Scenarios.Common;

namespace LavanderTyperWeb.Tests.Domain.Scenarios.Equipaments
{
    public class EquipamentScenario : Scenario
    {
        public Guid IdBranch { get; set; }
        public Branch Branch { get; set; }
        public string Name { get; set; }
        public double? Price { get; set; }
        public int? Quantity { get; set; }
        public string? Description { get; set; }
        public bool ExpectedIsValid { get; set; }

        public Equipament ToEquipament()
        {
            return new Equipament(IdBranch, Branch, Name, Price, Quantity, Description);
        }
    }
}
