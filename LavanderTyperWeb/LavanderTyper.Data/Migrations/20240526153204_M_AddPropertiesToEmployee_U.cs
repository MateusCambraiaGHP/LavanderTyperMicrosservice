using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LavanderTyperWeb.Data.Migrations
{
    /// <inheritdoc />
    public partial class M_AddPropertiesToEmployee_U : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Employee",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Employee",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "CltNumber",
                table: "Employee",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Complements",
                table: "Employee",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Number",
                table: "Employee",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<double>(
                name: "SalaryPerHour",
                table: "Employee",
                type: "double",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "CltNumber",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "Complements",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "SalaryPerHour",
                table: "Employee");
        }
    }
}
