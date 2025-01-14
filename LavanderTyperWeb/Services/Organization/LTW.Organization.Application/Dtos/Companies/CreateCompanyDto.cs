namespace LTW.Organization.Application.Dtos.Companies
{
  public class CreateCompanyDto
  {
    public string Name { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string? CNPJ { get; set; }
  }
}
