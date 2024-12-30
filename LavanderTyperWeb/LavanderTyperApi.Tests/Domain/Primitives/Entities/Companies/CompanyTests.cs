using LavanderTyperWeb.Domain.Primitives.Entities.Companies;
using LavanderTyperWeb.Tests.Domain.Scenarios.Companies;

namespace LavanderTyperWeb.Tests.Domain.Primitives.Entities.Companies
{
    public class CompanyTests
    {
        [Theory]
        [MemberData(nameof(CompanyScenarios.GetScenarios), MemberType = typeof(CompanyScenarios))]
        public void TestCompanyValidation(CompanyScenario scenario)
        {
            //Arrange
            var company = scenario.ToCompany();

            //Act
            bool isValid = ValidateCompany(company);

            //Assert
            Assert.Equal(scenario.ExpectedIsValid, isValid);
        }

        private bool ValidateCompany(Company company)
        {
            if (string.IsNullOrWhiteSpace(company.Name) ||
                string.IsNullOrWhiteSpace(company.Address))
            {
                return false;
            }

            return true;
        }
    }
}