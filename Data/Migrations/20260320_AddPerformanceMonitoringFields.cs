using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CVM_FinalProject.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddPerformanceMonitoringFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "tasks_completed",
                table: "PerformanceRecords",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "tasks_pending",
                table: "PerformanceRecords",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "performance_rating",
                table: "PerformanceRecords",
                type: "int",
                nullable: false,
                defaultValue: 3);

            migrationBuilder.AddCheckConstraint(
                name: "CK_PerformanceRating",
                table: "PerformanceRecords",
                sql: "[performance_rating] >= 1 AND [performance_rating] <= 5");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_PerformanceRating",
                table: "PerformanceRecords");

            migrationBuilder.DropColumn(
                name: "tasks_completed",
                table: "PerformanceRecords");

            migrationBuilder.DropColumn(
                name: "tasks_pending",
                table: "PerformanceRecords");

            migrationBuilder.DropColumn(
                name: "performance_rating",
                table: "PerformanceRecords");
        }
    }
}
