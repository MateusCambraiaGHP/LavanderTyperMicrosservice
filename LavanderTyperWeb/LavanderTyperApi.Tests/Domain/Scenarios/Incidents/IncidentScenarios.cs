using LavanderTyperWeb.Domain.Primitives.Entities.Branchs;
using LavanderTyperWeb.Domain.Primitives.Entities.Companies;
using LavanderTyperWeb.Domain.Primitives.Entities.Employees;
using LavanderTyperWeb.Domain.Primitives.Entities.Equipaments;
using LavanderTyperWeb.Domain.Primitives.Entities.Incidents.Enums;

namespace LavanderTyperWeb.Tests.Domain.Scenarios.Incidents
{
    public static class IncidentScenarios
    {
        public static IEnumerable<object[]> GetScenarios()
        {
            yield return new object[]
            {
                new IncidentScenario
                {
                    IdEmployee = Guid.NewGuid(),
                    IdBranch = Guid.NewGuid(),
                    IdEquipament = Guid.NewGuid(),
                    Employee = new Employee("John", "John", "John", "John", "John", "John", "John", 22.9, 2900, new(), new()),
                    Equipament = new Equipament(Guid.NewGuid(), new Branch(Guid.NewGuid(),"Main Branch", "Main Branch",new Company(
                        "Valid Company",
                        "456 Business St",
                        "12345678000195",
                        new List<Branch>()), new()), "Washing Machine", 15.8,20, "Washing Machine"),
                    Branch = new Branch(Guid.NewGuid(),"Main Branch", "Main Branch",new Company(
                        "Valid Company",
                        "456 Business St",
                        "12345678000195",
                        new List<Branch>()), new()),
                    Date = new DateOnly(2024, 8, 8),
                    Description = "Incident involving a washing machine.",
                    IncidentType = IncidentType.Absence,
                    ExpectedIsValid = true
                }
            };

            yield return new object[]
            {
                new IncidentScenario
                {
                    IdEmployee = Guid.NewGuid(),
                    IdBranch = Guid.NewGuid(),
                    IdEquipament = Guid.Empty,
                    Employee = new Employee("John", "John", "John", "John", "John", "John", "John", 22.9, 2900, new(), new()),
                    Equipament = null,
                    Branch = new Branch(Guid.NewGuid(),"Main Branch", "Main Branch",new Company(
                        "Valid Company",
                        "456 Business St",
                        "12345678000195",
                        new List<Branch>()), new()),
                    Date = new DateOnly(2024, 8, 8),
                    Description = "",
                    IncidentType = IncidentType.CoworkersConflict,
                    ExpectedIsValid = false
                }
            };

            yield return new object[]
            {
                new IncidentScenario
                {
                    IdEmployee = Guid.NewGuid(),
                    IdBranch = Guid.Empty,
                    IdEquipament = Guid.NewGuid(),
                    Employee = new Employee("John", "John", "John", "John", "John", "John", "John", 22.9, 2900, new(), new()),
                    Equipament =  new Equipament(Guid.NewGuid(), new Branch(Guid.NewGuid(),"Main Branch", "Main Branch",new Company(
                        "Valid Company",
                        "456 Business St",
                        "12345678000195",
                        new List<Branch>()), new()), "Washing Machine", 15.8,20, "Washing Machine")
                }
            };
        }
    }
}
