using LavanderTyperWeb.Domain.Primitives.Entities.Branchs;
using LavanderTyperWeb.Tests.Domain.Scenarios.Branchs;

namespace LavanderTyperWeb.Tests.Domain.Primitives.Entities.Branchs
{
    public class BranchTests
    {
        [Theory]
        [MemberData(nameof(BranchScenarios.GetScenarios), MemberType = typeof(BranchScenarios))]
        public void TestBranchValidation(BranchScenario scenario)
        {
            //Arrange
            var branch = scenario.ToBranch();

            //Act
            bool isValid = ValidateBranch(branch);

            //Assert
            Assert.Equal(scenario.ExpectedIsValid, isValid);
        }

        private bool ValidateBranch(Branch branch)
        {
            if (branch.IdCompany == Guid.Empty ||
                string.IsNullOrWhiteSpace(branch.Name) ||
                branch.Company == null)
            {
                return false;
            }

            return true;
        }
    }
}