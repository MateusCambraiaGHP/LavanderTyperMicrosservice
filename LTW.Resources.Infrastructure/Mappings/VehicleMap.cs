using LavanderTyperWeb.Domain.Primitives.Entities.Employees;
using LavanderTyperWeb.Domain.Primitives.Entities.Vehicles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LavanderTyperWeb.Data.Mappings
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

            entity.HasMany(v => v.Employees)
                .WithMany(e => e.Vehicles)
                .UsingEntity<Dictionary<string, object>>(
                    "VehicleEmployee",
                    ve => ve.HasOne<Employee>().WithMany().HasForeignKey("IdEmployee"),
                    ve => ve.HasOne<Vehicle>().WithMany().HasForeignKey("IdVehicle")
                );

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

            entity.HasOne(i => i.Branch)
                .WithMany()
                .HasForeignKey(i => i.IdBranch);

            entity.Property(e => e.LastModification)
                .HasColumnType("datetime");
        }
    }
}
