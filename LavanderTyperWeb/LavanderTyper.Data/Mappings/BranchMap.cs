using LavanderTyperWeb.Domain.Primitives.Entities.Branchs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LavanderTyperWeb.Data.Mappings
{
    public class BranchMap : IEntityTypeConfiguration<Branch>
    {
        public void Configure(EntityTypeBuilder<Branch> entity)
        {
            entity.ToTable("Branch");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.InsertionDate)
                .HasColumnType("datetime");

            entity.Property(e => e.Name)
                .HasMaxLength(50);

            entity.Property(e => e.Address)
                .HasMaxLength(70);

            entity.HasOne(b => b.Company)
                .WithMany(c => c.Branches)
                .HasForeignKey(b => b.IdCompany);

            entity.Property(e => e.LastModification)
                .HasColumnType("datetime");
        }
    }
}
