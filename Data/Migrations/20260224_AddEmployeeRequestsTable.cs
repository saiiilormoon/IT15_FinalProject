using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CVM_FinalProject.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddEmployeeRequestsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmployeeRequests",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RequestId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Department = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    RequestType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ApprovedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CompletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SubmittedByUserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubmittedByName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ApprovedByUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApprovedByName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CompletedByUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompletedByName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AdminNotes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeRequests", x => x.Id);
                });

            // Create index for faster queries
            migrationBuilder.CreateIndex(
                name: "IX_EmployeeRequests_SubmittedByUserId",
                table: "EmployeeRequests",
                column: "SubmittedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeRequests_Status",
                table: "EmployeeRequests",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeRequests_Department",
                table: "EmployeeRequests",
                column: "Department");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeRequests");
        }
    }
}
