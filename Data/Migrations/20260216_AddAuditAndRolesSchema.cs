using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CVM_FinalProject.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddAuditAndRolesSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Create Roles table
            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Role_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    role_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Role_ID);
                });

            // Create Employees table
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Employee_ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    user_ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    department_ID = table.Column<int>(type: "int", nullable: false),
                    position = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    employee_status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    date_hired = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Employee_ID);
                    table.ForeignKey(
                        name: "FK_Employees_AspNetUsers_user_ID",
                        column: x => x.user_ID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            // Create Departments table
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Department_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    department_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Department_ID);
                });

            // Create Reports table
            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    Report_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    report_type = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    generated_by = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    generated_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    report_data = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.Report_ID);
                    table.ForeignKey(
                        name: "FK_Reports_AspNetUsers_generated_by",
                        column: x => x.generated_by,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            // Create Performance_Records table
            migrationBuilder.CreateTable(
                name: "Performance_Records",
                columns: table => new
                {
                    Performance_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    employee_ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    evaluation_period = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    remarks = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    recorded_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Performance_Records", x => x.Performance_ID);
                    table.ForeignKey(
                        name: "FK_Performance_Records_Employees_employee_ID",
                        column: x => x.employee_ID,
                        principalTable: "Employees",
                        principalColumn: "Employee_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            // Create Budget table
            migrationBuilder.CreateTable(
                name: "Budget",
                columns: table => new
                {
                    Budget_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    department_ID = table.Column<int>(type: "int", nullable: false),
                    budget_period = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    allocated_amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    used_amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    remaining_amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Budget", x => x.Budget_ID);
                    table.ForeignKey(
                        name: "FK_Budget_Departments_department_ID",
                        column: x => x.department_ID,
                        principalTable: "Departments",
                        principalColumn: "Department_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            // Create Audit_Log table
            migrationBuilder.CreateTable(
                name: "Audit_Log",
                columns: table => new
                {
                    Audit_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    role_ID = table.Column<int>(type: "int", nullable: true),
                    action = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    assigned_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IP_address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Audit_Log", x => x.Audit_ID);
                    table.ForeignKey(
                        name: "FK_Audit_Log_AspNetUsers_user_ID",
                        column: x => x.user_ID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Audit_Log_Roles_role_ID",
                        column: x => x.role_ID,
                        principalTable: "Roles",
                        principalColumn: "Role_ID",
                        onDelete: ReferentialAction.SetNull);
                });

            // Create indexes
            migrationBuilder.CreateIndex(
                name: "IX_Employees_user_ID",
                table: "Employees",
                column: "user_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_department_ID",
                table: "Employees",
                column: "department_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_generated_by",
                table: "Reports",
                column: "generated_by");

            migrationBuilder.CreateIndex(
                name: "IX_Performance_Records_employee_ID",
                table: "Performance_Records",
                column: "employee_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Budget_department_ID",
                table: "Budget",
                column: "department_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Audit_Log_user_ID",
                table: "Audit_Log",
                column: "user_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Audit_Log_role_ID",
                table: "Audit_Log",
                column: "role_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "Audit_Log");
            migrationBuilder.DropTable(name: "Budget");
            migrationBuilder.DropTable(name: "Performance_Records");
            migrationBuilder.DropTable(name: "Reports");
            migrationBuilder.DropTable(name: "Employees");
            migrationBuilder.DropTable(name: "Departments");
            migrationBuilder.DropTable(name: "Roles");
        }
    }
}
