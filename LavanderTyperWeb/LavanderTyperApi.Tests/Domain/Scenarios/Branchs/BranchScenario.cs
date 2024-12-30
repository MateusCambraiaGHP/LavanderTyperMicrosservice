using LavanderTyperWeb.Domain.Primitives.Entities.Branchs;
using LavanderTyperWeb.Domain.Primitives.Entities.Companies;
using LavanderTyperWeb.Domain.Primitives.Entities.Employees;
using LavanderTyperWeb.Tests.Domain.Scenarios.Common;

namespace LavanderTyperWeb.Tests.Domain.Scenarios.Branchs
{
    public class BranchScenario : Scenario
    {
        public Guid IdCompany { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public Company Company { get; set; }
        public List<Employee> Employees { get; set; }
        public bool ExpectedIsValid { get; set; }

        public Branch ToBranch()
        {
            return new Branch(IdCompany, Name, Address, Company, Employees);
        }
    }
}
