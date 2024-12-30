using LavanderTyperWeb.Application.Features.ViewModel.Commom;
using System.Text.Json.Serialization;

namespace LavanderTyperWeb.Application.Features.ViewModel.Companies
{
    public class CompanyViewModel : BaseViewModel
    {
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string CNPJ { get; set; } = string.Empty;

        [JsonConstructor]
        public CompanyViewModel(string name, string address, string cNPJ) 
        {
            Name = name;
            Address = address;
            CNPJ = cNPJ;
        }

        public CompanyViewModel() { }
    }
}
