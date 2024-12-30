using LavanderTyperWeb.Domain.Primitives.Entities.Branchs;
using LavanderTyperWeb.Domain.Primitives.Entities.Companies;
using LavanderTyperWeb.Tests.Domain.Scenarios.Common;

namespace LavanderTyperWeb.Tests.Domain.Scenarios.Companies
{
    public class CompanyScenario : Scenario
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string? CNPJ { get; set; }
        public List<Branch> Branches { get; set; }
        public bool ExpectedIsValid { get; set; }

        public Company ToCompany()
        {
            return new Company(Name, Address, CNPJ, Branches);
        }
    }
}
