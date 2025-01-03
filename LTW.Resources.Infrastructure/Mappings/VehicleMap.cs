using LTW.Resources.Domain.Primitives.Entities.Vehicles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LTW.Resources.Infrastructure.Mappings
{
  public class VehicleMap : IEntityTypeConfiguration<Vehicle>
  {
    public void Configure(EntityTypeBuilder<Vehicle> entity)
    {
      entity.ToTable("Vehicle");

      entity.HasKey(e => e.Id);

      entity.Property(e => e.InsertionDate)
          .HasColumnType("datetime");

      entity.Property(v => v.Name)
                 .HasMaxLength(50);

      entity.Property(v => v.Description)
          .HasMaxLength(500);

      entity.Property(v => v.LicensePlate)
          .HasMaxLength(50);

      entity.Property(v => v.VehicleCondition)
          .HasConversion<int>();

      entity.Property(v => v.Price)
          .HasColumnType("decimal(18,2)");

      entity.OwnsMany(e => e.Gas, a =>
      {
        a.WithOwner().HasForeignKey("VehicleId");
        a.ToTable("VehicleGas");
        a.Property<int>("Id");
        a.HasKey("Id");

        a.Property(g => g.Price)
                  .HasColumnName("Price")
                  .HasPrecision(20, 4);

        a.Property(g => g.Date)
                  .HasColumnName("Date");
      });

      entity.Property(e => e.LastModification)
          .HasColumnType("datetime");
    }
  }
}
