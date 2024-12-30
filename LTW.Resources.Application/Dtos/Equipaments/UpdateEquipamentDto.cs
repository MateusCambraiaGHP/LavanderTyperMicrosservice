using LavanderTyperWeb.Application.Dtos.Branchs;
using LavanderTyperWeb.Domain.Primitives.Entities.Branchs;

namespace LavanderTyperWeb.Application.Dtos.Equipaments
{
    public class UpdateEquipamentDto
    {
        public Guid IdBranch { get; set; }
        public CreateBranchDto Branch { get; set; } = new();
        public string Name { get; set; } = string.Empty;
        public double? Price { get; set; }
        public int? Quantity { get; set; }
        public string? Description { get; set; }
    }
}
