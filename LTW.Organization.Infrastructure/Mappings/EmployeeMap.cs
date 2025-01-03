using LTW.Organization.Domain.Primitives.Entities.Branchs;
using LTW.Organization.Domain.Primitives.Entities.Employees;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LTW.Organization.Infrastructure.Mappings
{
  public class EmployeeMap : IEntityTypeConfiguration<Employee>
  {
    public void Configure(EntityTypeBuilder<Employee> entity)
    {
      entity.ToTable("Employee");

      entity.HasKey(e => e.Id);

      entity.Property(e => e.InsertionDate)
          .HasColumnType("datetime");

      entity.Property(e => e.FirstName)
          .HasMaxLength(50);

      entity.Property(e => e.LastName)
          .HasMaxLength(50);

      entity.Property(e => e.Address)
          .HasMaxLength(70);

      entity.Property(e => e.Number)
          .HasMaxLength(30);

      entity.Property(e => e.City)
          .HasMaxLength(50);

      entity.Property(e => e.Complements)
          .HasMaxLength(300);

      entity.Property(e => e.LicenseNumber)
          .HasMaxLength(80);

      entity.Property(e => e.Salary)
          .HasPrecision(30, 4);

      entity.Property(e => e.SalaryPerHour)
          .HasPrecision(30, 4);

      entity.HasMany(e => e.Branches)
                  .WithMany(b => b.Employees)
                  .UsingEntity<Dictionary<string, object>>(
                      "EmployeeBranch",
                      j => j
                          .HasOne<Branch>()
                          .WithMany()
                          .HasForeignKey("BranchId")
                          .HasConstraintName("FK_EmployeeBranch_Branch")
                          .OnDelete(DeleteBehavior.Cascade),
                      j => j
                          .HasOne<Employee>()
                          .WithMany()
                          .HasForeignKey("EmployeeId")
                          .HasConstraintName("FK_EmployeeBranch_Employee")
                          .OnDelete(DeleteBehavior.Cascade)
                  );

      entity.Property(e => e.LastModification)
          .HasColumnType("datetime");
    }
  }
}
