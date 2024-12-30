using LavanderTyperWeb.Domain.Primitives.Entities.Equipaments;
using LavanderTyperWeb.Tests.Domain.Scenarios.Equipaments;

namespace LavanderTyperWeb.Tests.Domain.Primitives.Entities.Equipaments
{
    public class EquipamentTests
    {
        [Theory]
        [MemberData(nameof(EquipamentScenarios.GetScenarios), MemberType = typeof(EquipamentScenarios))]
        public void TestEquipamentValidation(EquipamentScenario scenario)
        {
            //Arrange
            var equipament = scenario.ToEquipament();

            //Act
            bool isValid = ValidateEquipament(equipament);

            //Assert
            Assert.Equal(scenario.ExpectedIsValid, isValid);
        }

        private bool ValidateEquipament(Equipament equipament)
        {
            if (equipament.IdBranch == Guid.Empty ||
                string.IsNullOrWhiteSpace(equipament.Name) ||
                equipament.Quantity <= 0)
            {
                return false;
            }

            return true;
        }
    }
}