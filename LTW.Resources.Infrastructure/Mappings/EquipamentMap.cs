using LTW.Resources.Domain.Primitives.Entities.Equipaments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LTW.Resources.Infrastructure.Mappings
{
  public class EquipamentMap : IEntityTypeConfiguration<Equipament>
  {
    public void Configure(EntityTypeBuilder<Equipament> entity)
    {
      entity.ToTable("Equipament");

      entity.HasKey(e => e.Id);

      entity.Property(e => e.InsertionDate)
          .HasColumnType("datetime");

      entity.Property(e => e.Name)
          .HasMaxLength(50);

      entity.Property(e => e.Description)
          .HasMaxLength(50);

      entity.Property(e => e.Quantity);

      entity.Property(e => e.Price)
          .HasPrecision(20, 4);

      entity.Property(e => e.LastModification)
          .HasColumnType("datetime");
    }
  }
}
