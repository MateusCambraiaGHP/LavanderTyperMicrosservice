using LTW.Organization.Application.Features.ViewModel.Commom;
using System.Text.Json.Serialization;

namespace LTW.Organization.Application.Features.ViewModel.Branchs
{
  public class BranchViewModel : BaseViewModel
  {
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;

    [JsonConstructor]
    public BranchViewModel(string firstName, string lastName)
    {
      FirstName = firstName;
      LastName = lastName;
    }

    public BranchViewModel() { }
  }
}
