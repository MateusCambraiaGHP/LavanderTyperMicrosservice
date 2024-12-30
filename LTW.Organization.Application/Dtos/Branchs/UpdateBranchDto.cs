namespace LavanderTyperWeb.Application.Dtos.Branchs
{
    public class UpdateBranchDto
    {
        public Guid Id { get; set; }
        public Guid IdCompany { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
    }
}
