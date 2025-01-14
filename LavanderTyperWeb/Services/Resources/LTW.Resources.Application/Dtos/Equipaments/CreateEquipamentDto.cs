namespace LTW.Resources.Application.Dtos.Equipaments
{
  public class CreateEquipamentDto
  {
    public Guid IdBranch { get; set; }
    public string Name { get; set; } = string.Empty;
    public double? Price { get; set; }
    public int? Quantity { get; set; }
    public string? Description { get; set; }
  }
}
