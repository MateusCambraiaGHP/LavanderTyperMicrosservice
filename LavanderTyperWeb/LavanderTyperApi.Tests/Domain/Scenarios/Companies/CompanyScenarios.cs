using LavanderTyperWeb.Domain.Primitives.Entities.Branchs;

namespace LavanderTyperWeb.Tests.Domain.Scenarios.Companies
{
    public static class CompanyScenarios
    {
        public static IEnumerable<object[]> GetScenarios()
        {
            yield return new object[]
            {
                new CompanyScenario
                {
                    Name = "Valid Company",
                    Address = "456 Business St",
                    CNPJ = "12345678000195",
                    Branches = new List<Branch> { },
                    ExpectedIsValid = true
                }
            };

            yield return new object[]
            {
                new CompanyScenario
                {
                    Name = "",
                    Address = "456 Business St",
                    CNPJ = null,
                    Branches = new List<Branch> { },
                    ExpectedIsValid = false
                }
            };

            yield return new object[]
            {
                new CompanyScenario
                {
                    Name = "Another Valid Company",
                    Address = "",
                    CNPJ = "98765432000199",
                    Branches = new List<Branch>(),
                    ExpectedIsValid = false
                }
            };
        }
    }
}
