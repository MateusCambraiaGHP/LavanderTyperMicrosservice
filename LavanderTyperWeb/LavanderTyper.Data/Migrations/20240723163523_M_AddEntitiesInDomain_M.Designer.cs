﻿// <auto-generated />
using System;
using LavanderTyperWeb.Data.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LavanderTyperWeb.Data.Migrations
{
    [DbContext(typeof(ApplicationMySqlDbContext))]
    [Migration("20240723163523_M_AddEntitiesInDomain_M")]
    partial class M_AddEntitiesInDomain_M
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.19")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("EmployeeBranch", b =>
                {
                    b.Property<Guid>("BranchId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("EmployeeId")
                        .HasColumnType("char(36)");

                    b.HasKey("BranchId", "EmployeeId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("EmployeeBranch");
                });

            modelBuilder.Entity("LavanderTyperWeb.Domain.Primitives.Entities.Branchs.Branch", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("varchar(70)");

                    b.Property<DateTime?>("DeletionDate")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("IdCompany")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("InsertionDate")
                        .HasColumnType("datetime");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("LastModification")
                        .HasColumnType("datetime");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("IdCompany");

                    b.ToTable("Branch", (string)null);
                });

            modelBuilder.Entity("LavanderTyperWeb.Domain.Primitives.Entities.Companies.Company", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("varchar(70)");

                    b.Property<string>("CNPJ")
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)");

                    b.Property<DateTime?>("DeletionDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("InsertionDate")
                        .HasColumnType("datetime");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("LastModification")
                        .HasColumnType("datetime");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Company", (string)null);
                });

            modelBuilder.Entity("LavanderTyperWeb.Domain.Primitives.Entities.Employees.Employee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("varchar(70)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Complements")
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)");

                    b.Property<DateTime?>("DeletionDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("InsertionDate")
                        .HasColumnType("datetime");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("LastModification")
                        .HasColumnType("datetime");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("LicenseNumber")
                        .HasMaxLength(80)
                        .HasColumnType("varchar(80)");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<double?>("Salary")
                        .HasPrecision(30, 4)
                        .HasColumnType("double");

                    b.Property<double?>("SalaryPerHour")
                        .HasPrecision(30, 4)
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.ToTable("Employee", (string)null);
                });

            modelBuilder.Entity("LavanderTyperWeb.Domain.Primitives.Entities.Equipaments.Equipament", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("DeletionDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<Guid>("IdBranch")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("InsertionDate")
                        .HasColumnType("datetime");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("LastModification")
                        .HasColumnType("datetime");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<double?>("Price")
                        .HasPrecision(20, 4)
                        .HasColumnType("double");

                    b.Property<int?>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdBranch");

                    b.ToTable("Equipament", (string)null);
                });

            modelBuilder.Entity("LavanderTyperWeb.Domain.Primitives.Entities.Loggers.Logger", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("CorrelationalId")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime?>("DeletionDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("InsertionDate")
                        .HasColumnType("datetime");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("LastModification")
                        .HasColumnType("datetime");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Method")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Payload")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.Property<string>("Response")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.Property<string>("Source")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("Type")
                        .HasMaxLength(30)
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Logger", (string)null);
                });

            modelBuilder.Entity("LavanderTyperWeb.Domain.Primitives.Entities.TimeSheets.Incident", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<DateTime?>("DeletionDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.Property<Guid>("IdBranch")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("IdEmployee")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("IdEquipament")
                        .HasColumnType("char(36)");

                    b.Property<int>("IncidentType")
                        .HasColumnType("int");

                    b.Property<DateTime>("InsertionDate")
                        .HasColumnType("datetime");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("LastModification")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("IdBranch");

                    b.HasIndex("IdEmployee");

                    b.HasIndex("IdEquipament");

                    b.ToTable("Incident", (string)null);
                });

            modelBuilder.Entity("LavanderTyperWeb.Domain.Primitives.Entities.Vehicles.Vehicle", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("DeletionDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.Property<Guid>("IdBranch")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("InsertionDate")
                        .HasColumnType("datetime");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("LastModification")
                        .HasColumnType("datetime");

                    b.Property<string>("LicensePlate")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<decimal?>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("VehicleCondition")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdBranch");

                    b.ToTable("Vehicle", (string)null);
                });

            modelBuilder.Entity("VehicleEmployee", b =>
                {
                    b.Property<Guid>("IdEmployee")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("IdVehicle")
                        .HasColumnType("char(36)");

                    b.HasKey("IdEmployee", "IdVehicle");

                    b.HasIndex("IdVehicle");

                    b.ToTable("VehicleEmployee");
                });

            modelBuilder.Entity("EmployeeBranch", b =>
                {
                    b.HasOne("LavanderTyperWeb.Domain.Primitives.Entities.Branchs.Branch", null)
                        .WithMany()
                        .HasForeignKey("BranchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_EmployeeBranch_Branch");

                    b.HasOne("LavanderTyperWeb.Domain.Primitives.Entities.Employees.Employee", null)
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_EmployeeBranch_Employee");
                });

            modelBuilder.Entity("LavanderTyperWeb.Domain.Primitives.Entities.Branchs.Branch", b =>
                {
                    b.HasOne("LavanderTyperWeb.Domain.Primitives.Entities.Companies.Company", "Company")
                        .WithMany("Branches")
                        .HasForeignKey("IdCompany")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("LavanderTyperWeb.Domain.Primitives.Entities.Equipaments.Equipament", b =>
                {
                    b.HasOne("LavanderTyperWeb.Domain.Primitives.Entities.Branchs.Branch", "Branch")
                        .WithMany()
                        .HasForeignKey("IdBranch")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Branch");
                });

            modelBuilder.Entity("LavanderTyperWeb.Domain.Primitives.Entities.TimeSheets.Incident", b =>
                {
                    b.HasOne("LavanderTyperWeb.Domain.Primitives.Entities.Branchs.Branch", "Branch")
                        .WithMany()
                        .HasForeignKey("IdBranch")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LavanderTyperWeb.Domain.Primitives.Entities.Employees.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("IdEmployee")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LavanderTyperWeb.Domain.Primitives.Entities.Equipaments.Equipament", "Equipament")
                        .WithMany()
                        .HasForeignKey("IdEquipament")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Branch");

                    b.Navigation("Employee");

                    b.Navigation("Equipament");
                });

            modelBuilder.Entity("LavanderTyperWeb.Domain.Primitives.Entities.Vehicles.Vehicle", b =>
                {
                    b.HasOne("LavanderTyperWeb.Domain.Primitives.Entities.Branchs.Branch", "Branch")
                        .WithMany()
                        .HasForeignKey("IdBranch")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsMany("LavanderTyperWeb.Domain.Primitives.Entities.Vehicles.ValueObjects.Gas", "Gas", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            b1.Property<DateOnly>("Date")
                                .HasColumnType("date")
                                .HasColumnName("Date");

                            b1.Property<double>("Price")
                                .HasPrecision(20, 4)
                                .HasColumnType("double")
                                .HasColumnName("Price");

                            b1.Property<Guid>("VehicleId")
                                .HasColumnType("char(36)");

                            b1.HasKey("Id");

                            b1.HasIndex("VehicleId");

                            b1.ToTable("VehicleGas", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("VehicleId");
                        });

                    b.Navigation("Branch");

                    b.Navigation("Gas");
                });

            modelBuilder.Entity("VehicleEmployee", b =>
                {
                    b.HasOne("LavanderTyperWeb.Domain.Primitives.Entities.Employees.Employee", null)
                        .WithMany()
                        .HasForeignKey("IdEmployee")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LavanderTyperWeb.Domain.Primitives.Entities.Vehicles.Vehicle", null)
                        .WithMany()
                        .HasForeignKey("IdVehicle")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LavanderTyperWeb.Domain.Primitives.Entities.Companies.Company", b =>
                {
                    b.Navigation("Branches");
                });
#pragma warning restore 612, 618
        }
    }
}
