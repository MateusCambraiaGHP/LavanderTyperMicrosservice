using LavanderTyperWeb.Domain.Primitives.Entities.Branchs;
using LavanderTyperWeb.Domain.Primitives.Entities.Companies;
using LavanderTyperWeb.Domain.Primitives.Entities.Employees;

namespace LavanderTyperWeb.Tests.Domain.Scenarios.Branchs
{
    public static class BranchScenarios
    {
        public static IEnumerable<object[]> GetScenarios()
        {
            yield return new object[]
            {
                new BranchScenario
                { 
                    IdCompany = Guid.NewGuid(),
                    Name = "Valid Branch",
                    Address = "123 Main St",
                    Company = new Company(
                        "Valid Company",
                        "456 Business St",
                        "12345678000195",
                        new List<Branch>()),
                    Employees = new List<Employee> { },
                    ExpectedIsValid = false
                }
            };

            yield return new object[]
            {
                new BranchScenario
                {
                    IdCompany = Guid.Empty,
                    Name = null,
                    Address = "123 Main St",
                    Company = null,
                    Employees = new List<Employee>(),
                    ExpectedIsValid = true
                }
            };
        }
    }
}
