using LavanderTyperWeb.Core.DomainObjects;
using LavanderTyperWeb.Domain.Primitives.Entities.Branchs;

namespace LTW.Resources.Domain.Primitives.Entities.Equipaments
{
  public class Equipament : EntityBase
  {
    public Guid IdBranch { get; set; }
    public Branch Branch { get; set; } = new();
    public string Name { get; set; } = string.Empty;
    public double? Price { get; set; }
    public int? Quantity { get; set; }
    public string? Description { get; set; }

    private Equipament() { }

    public Equipament(
        Guid idBranch,
        Branch branch,
        string name,
        double? price,
        int? quantity,
        string? description)
    {
      IdBranch = idBranch;
      Branch = branch;
      Name = name;
      Price = price;
      Quantity = quantity;
      Description = description;
    }
  }
}
