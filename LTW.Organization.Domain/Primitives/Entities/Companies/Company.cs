using LTW.Core.DomainObjects;
using LTW.Organization.Domain.Primitives.Entities.Branchs;

namespace LTW.Organization.Domain.Primitives.Entities.Companies
{
  public class Company : EntityBase
  {
    public string Name { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string? CNPJ { get; set; }
    public List<Branch> Branches { get; set; } = new();

    internal Company() { }

    public Company(
        string name,
        string address,
        string? cNPJ,
        List<Branch> branches)
    {
      Name = name;
      Address = address;
      CNPJ = cNPJ;
      Branches = branches;
    }
  }
}
