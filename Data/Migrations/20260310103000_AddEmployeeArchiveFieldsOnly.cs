using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CVM_FinalProject.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddEmployeeArchiveFieldsOnly : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Only add the archive columns to the Employees table
            migrationBuilder.AddColumn<bool>(
                name: "is_archived",
                table: "Employees",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "archive_date",
                table: "Employees",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "archive_date",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "is_archived",
                table: "Employees");
        }
    }
}
