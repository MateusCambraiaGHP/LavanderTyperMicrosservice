using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using IncidentEntity = LTW.Incident.Domain.Primitives.Entities.Incidents.Incident;

namespace LTW.Incident.Infrastructure.Mappings
{
  public class IncidentMap : IEntityTypeConfiguration<IncidentEntity>
  {
    public void Configure(EntityTypeBuilder<IncidentEntity> entity)
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

      entity.Property(e => e.LastModification)
          .HasColumnType("datetime");
    }
  }
}
