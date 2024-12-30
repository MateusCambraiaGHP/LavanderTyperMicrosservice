using LavanderTyperWeb.Domain.Primitives.Entities.Incidents;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LavanderTyperWeb.Data.Mappings
{
    public class IncidentMap : IEntityTypeConfiguration<Incident>
    {
        public void Configure(EntityTypeBuilder<Incident> entity)
        {
            entity.ToTable("Incident");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.InsertionDate)
                .HasColumnType("datetime");

            entity.Property(e => e.Date)
                .HasColumnType("date");

            entity.Property(i => i.Description)
                .HasMaxLength(500);

            entity.Property(i => i.IncidentType)
                .HasConversion<int>();

            entity.HasOne(i => i.Employee)
                .WithMany()
                .HasForeignKey(i => i.IdEmployee);

            entity.HasOne(i => i.Branch)
                .WithMany()
                .HasForeignKey(i => i.IdBranch);

            entity.HasOne(i => i.Equipament)
                .WithMany()
                .HasForeignKey(i => i.IdEquipament);

            entity.Property(e => e.LastModification)
                .HasColumnType("datetime");
        }
    }
}
