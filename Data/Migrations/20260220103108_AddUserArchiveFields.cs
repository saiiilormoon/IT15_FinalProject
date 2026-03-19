using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CVM_FinalProject.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddUserArchiveFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ArchivedAt",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ArchivedBy",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsArchived",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ArchivedAt",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ArchivedBy",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IsArchived",
                table: "AspNetUsers");
        }
    }
}
