namespace LTW.Organization.Application.Dtos.Branchs
{
  public class CreateBranchDto
  {
    public Guid IdCompany { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
  }
}
