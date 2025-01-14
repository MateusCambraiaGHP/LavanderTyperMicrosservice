using LTW.Organization.Application.Features.ViewModel.Commom;
using System.Text.Json.Serialization;

namespace LTW.Organization.Application.Features.ViewModel.Employees
{
  public class EmployeeViewModel : BaseViewModel
  {
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;

    [JsonConstructor]
    public EmployeeViewModel(string firstName, string lastName)
    {
      FirstName = firstName;
      LastName = lastName;
    }

    public EmployeeViewModel() { }
  }
}
