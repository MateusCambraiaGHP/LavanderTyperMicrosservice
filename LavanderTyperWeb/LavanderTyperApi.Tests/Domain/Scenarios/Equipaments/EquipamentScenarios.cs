using LavanderTyperWeb.Domain.Primitives.Entities.Branchs;
using LavanderTyperWeb.Domain.Primitives.Entities.Companies;

namespace LavanderTyperWeb.Tests.Domain.Scenarios.Equipaments
{
    public static class EquipamentScenarios
    {
        public static IEnumerable<object[]> GetScenarios()
        {
            yield return new object[]
            {
                new EquipamentScenario
                {
                    IdBranch = Guid.NewGuid(),
                    Branch = new Branch(Guid.NewGuid(),"Main Branch", "Main Branch",new Company(
                        "Valid Company",
                        "456 Business St",
                        "12345678000195",
                        new List<Branch>()), new()),
                    Name = "Washing Machine",
                    Price = 1500.0,
                    Quantity = 10,
                    Description = "Industrial washing machine.",
                    ExpectedIsValid = true
                }
            };

            yield return new object[]
            {
                new EquipamentScenario
                {
                    IdBranch = Guid.Empty,
                    Branch = new Branch(Guid.NewGuid(),"Main Branch", "Main Branch",new Company(
                        "Valid Company",
                        "456 Business St",
                        "12345678000195",
                        new List<Branch>()), new()),
                    Name = "",
                    Price = null,
                    Quantity = -5,
                    Description = "Some description",
                    ExpectedIsValid = false
                }
            };

            yield return new object[]
            {
                new EquipamentScenario
                {
                    IdBranch = Guid.NewGuid(),
                    Branch = new Branch(Guid.NewGuid(),"Main Branch", "Main Branch",new Company(
                        "Valid Company",
                        "456 Business St",
                        "12345678000195",
                        new List<Branch>()), new()),
                    Name = "Dryer",
                    Price = null,
                    Quantity = 3,
                    Description = null,
                    ExpectedIsValid = true
                }
            };
        }
    }
}
