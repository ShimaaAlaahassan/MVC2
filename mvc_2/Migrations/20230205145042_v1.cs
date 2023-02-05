using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC2.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "departments",
                columns: table => new
                {
                    Number = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    empm = table.Column<int>(name: "emp_m", type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_departments", x => x.Number);
                });

            migrationBuilder.CreateTable(
                name: "employees",
                columns: table => new
                {
                    SSN = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sex = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "date", nullable: true),
                    Salary = table.Column<decimal>(type: "money", nullable: true),
                    SuperVisorSSN = table.Column<int>(type: "int", nullable: true),
                    deptIdw = table.Column<int>(name: "deptId_w", type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employees", x => x.SSN);
                    table.ForeignKey(
                        name: "FK_employees_departments_deptId_w",
                        column: x => x.deptIdw,
                        principalTable: "departments",
                        principalColumn: "Number");
                    table.ForeignKey(
                        name: "FK_employees_employees_SuperVisorSSN",
                        column: x => x.SuperVisorSSN,
                        principalTable: "employees",
                        principalColumn: "SSN");
                });

            migrationBuilder.CreateTable(
                name: "locations",
                columns: table => new
                {
                    Location = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DeptNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_locations", x => new { x.DeptNumber, x.Location });
                    table.ForeignKey(
                        name: "FK_locations_departments_DeptNumber",
                        column: x => x.DeptNumber,
                        principalTable: "departments",
                        principalColumn: "Number",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "projects",
                columns: table => new
                {
                    Number = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeptNum = table.Column<int>(type: "int", nullable: false),
                    DepartmentsNumber = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_projects", x => x.Number);
                    table.ForeignKey(
                        name: "FK_projects_departments_DepartmentsNumber",
                        column: x => x.DepartmentsNumber,
                        principalTable: "departments",
                        principalColumn: "Number");
                });

            migrationBuilder.CreateTable(
                name: "dependents",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sex = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "date", nullable: true),
                    Relationship = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ESSN = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dependents", x => x.id);
                    table.ForeignKey(
                        name: "FK_dependents_employees_ESSN",
                        column: x => x.ESSN,
                        principalTable: "employees",
                        principalColumn: "SSN");
                });

            migrationBuilder.CreateTable(
                name: "workOns",
                columns: table => new
                {
                    ESSN = table.Column<int>(type: "int", nullable: false),
                    projectNum = table.Column<int>(type: "int", nullable: false),
                    Hours = table.Column<int>(type: "int", nullable: false),
                    ProjectNumber = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_workOns", x => new { x.ESSN, x.projectNum });
                    table.ForeignKey(
                        name: "FK_workOns_employees_ESSN",
                        column: x => x.ESSN,
                        principalTable: "employees",
                        principalColumn: "SSN",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_workOns_projects_ProjectNumber",
                        column: x => x.ProjectNumber,
                        principalTable: "projects",
                        principalColumn: "Number");
                });

            migrationBuilder.CreateIndex(
                name: "IX_departments_emp_m",
                table: "departments",
                column: "emp_m",
                unique: true,
                filter: "[emp_m] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_dependents_ESSN",
                table: "dependents",
                column: "ESSN");

            migrationBuilder.CreateIndex(
                name: "IX_employees_deptId_w",
                table: "employees",
                column: "deptId_w");

            migrationBuilder.CreateIndex(
                name: "IX_employees_SuperVisorSSN",
                table: "employees",
                column: "SuperVisorSSN");

            migrationBuilder.CreateIndex(
                name: "IX_projects_DepartmentsNumber",
                table: "projects",
                column: "DepartmentsNumber");

            migrationBuilder.CreateIndex(
                name: "IX_workOns_ProjectNumber",
                table: "workOns",
                column: "ProjectNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_departments_employees_emp_m",
                table: "departments",
                column: "emp_m",
                principalTable: "employees",
                principalColumn: "SSN");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_departments_employees_emp_m",
                table: "departments");

            migrationBuilder.DropTable(
                name: "dependents");

            migrationBuilder.DropTable(
                name: "locations");

            migrationBuilder.DropTable(
                name: "workOns");

            migrationBuilder.DropTable(
                name: "projects");

            migrationBuilder.DropTable(
                name: "employees");

            migrationBuilder.DropTable(
                name: "departments");
        }
    }
}
