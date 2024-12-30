using LavanderTyperWeb.Domain.Primitives.Entities.Companies;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LavanderTyperWeb.Data.Mappings
{
    public class CompanyMap : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> entity)
        {
            entity.ToTable("Company");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.InsertionDate)
                .HasColumnType("datetime");

            entity.Property(e => e.Name)
                .HasMaxLength(50);

            entity.Property(e => e.Address)
                .HasMaxLength(70);

            entity.Property(e => e.CNPJ)
                .HasMaxLength(60);

            entity.HasMany(e => e.Branches)
                .WithOne(b => b.Company)
                .HasForeignKey(b => b.IdCompany);

            entity.Property(e => e.LastModification)
                .HasColumnType("datetime");
        }
    }
}
