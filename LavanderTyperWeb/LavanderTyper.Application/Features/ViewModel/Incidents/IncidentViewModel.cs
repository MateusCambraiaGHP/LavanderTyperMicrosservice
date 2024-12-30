using LavanderTyperWeb.Application.Features.ViewModel.Commom;
using System.Text.Json.Serialization;

namespace LavanderTyperWeb.Application.Features.ViewModel.Incidents
{
    public class IncidentViewModel : BaseViewModel
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        [JsonConstructor]
        public IncidentViewModel(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public IncidentViewModel() { }
    }
}
