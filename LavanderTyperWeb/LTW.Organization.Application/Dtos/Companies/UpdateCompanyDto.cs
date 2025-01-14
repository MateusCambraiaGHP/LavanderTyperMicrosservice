using LTW.Organization.Application.Dtos.Branchs;

namespace LTW.Organization.Application.Dtos.Companies
{
  public class UpdateCompanyDto
  {
    public string Name { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string? CNPJ { get; set; }
    public List<CreateBranchDto> Branches { get; set; } = new();
  }
}
