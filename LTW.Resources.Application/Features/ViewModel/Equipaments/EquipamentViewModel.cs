using LTW.Organization.Application.Features.ViewModel.Commom;
using System.Text.Json.Serialization;

namespace LTW.Resources.Application.Features.ViewModel.Equipaments
{
  public class EquipamentViewModel : BaseViewModel
  {
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;

    [JsonConstructor]
    public EquipamentViewModel(string firstName, string lastName)
    {
      FirstName = firstName;
      LastName = lastName;
    }

    public EquipamentViewModel() { }
  }
}
