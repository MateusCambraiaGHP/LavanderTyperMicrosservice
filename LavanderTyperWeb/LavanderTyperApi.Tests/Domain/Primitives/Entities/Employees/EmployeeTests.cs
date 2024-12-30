using LavanderTyperWeb.Domain.Primitives.Entities.Employees;
using LavanderTyperWeb.Tests.Domain.Scenarios.Employees;

namespace LavanderTyperWeb.Tests.Domain.Primitives.Entities.Employees
{
    public class EmployeeTests
    {
        [Theory]
        [MemberData(nameof(EmployeeScenarios.GetScenarios), MemberType = typeof(EmployeeScenarios))]
        public void TestEmployeeValidation(EmployeeScenario scenario)
        {
            //Arrange
            var employee = scenario.ToEmployee();

            //Act
            bool isValid = ValidateEmployee(employee);

            //Assert
            Assert.Equal(scenario.ExpectedIsValid, isValid);
        }

        private bool ValidateEmployee(Employee employee)
        {
            if (string.IsNullOrWhiteSpace(employee.FirstName) ||
                string.IsNullOrWhiteSpace(employee.LastName) ||
                string.IsNullOrWhiteSpace(employee.Address) ||
                string.IsNullOrWhiteSpace(employee.Number) ||
                string.IsNullOrWhiteSpace(employee.City))
            {
                return false;
            }

            return true;
        }
    }
}