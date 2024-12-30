using LavanderTyperWeb.Domain.Primitives.Entities.Loggers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LavanderTyperWeb.Data.Mappings
{
    public class LoggerMap : IEntityTypeConfiguration<Logger>
    {
        public void Configure(EntityTypeBuilder<Logger> entity)
        {
            entity.ToTable("Logger");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.InsertionDate)
                .HasColumnType("datetime");

            entity.Property(e => e.CorrelationalId)
                .HasMaxLength(50);

            entity.Property(e => e.Source)
                .HasMaxLength(50);

            entity.Property(e => e.Message)
                .HasMaxLength(200);

            entity.Property(e => e.Method)
                .HasMaxLength(200);

            entity.Property(e => e.Payload)
                .HasMaxLength(500);

            entity.Property(e => e.Response)
                .HasMaxLength(500);

            entity.Property(e => e.Type)
                .HasMaxLength(30);

            entity.Property(e => e.LastModification)
                .HasColumnType("datetime");
        }
    }
}
