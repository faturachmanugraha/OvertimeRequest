using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Overtime_API.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_M_Client",
                columns: table => new
                {
                    ClientID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_Client", x => x.ClientID);
                });

            migrationBuilder.CreateTable(
                name: "TB_M_Department",
                columns: table => new
                {
                    DepartmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NIKManager = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_Department", x => x.DepartmentID);
                });

            migrationBuilder.CreateTable(
                name: "TB_M_Position",
                columns: table => new
                {
                    PositionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PositionName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_Position", x => x.PositionID);
                });

            migrationBuilder.CreateTable(
                name: "TB_M_Role",
                columns: table => new
                {
                    RoleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_Role", x => x.RoleID);
                });

            migrationBuilder.CreateTable(
                name: "TB_M_Employee",
                columns: table => new
                {
                    NIK = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Salary = table.Column<int>(type: "int", nullable: false),
                    PositionID = table.Column<int>(type: "int", nullable: false),
                    ClientID = table.Column<int>(type: "int", nullable: false),
                    DepartmentID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_Employee", x => x.NIK);
                    table.UniqueConstraint("AK_TB_M_Employee_Email", x => x.Email);
                    table.UniqueConstraint("AK_TB_M_Employee_PhoneNumber", x => x.PhoneNumber);
                    table.ForeignKey(
                        name: "FK_TB_M_Employee_TB_M_Client_ClientID",
                        column: x => x.ClientID,
                        principalTable: "TB_M_Client",
                        principalColumn: "ClientID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_M_Employee_TB_M_Department_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "TB_M_Department",
                        principalColumn: "DepartmentID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_M_Employee_TB_M_Position_PositionID",
                        column: x => x.PositionID,
                        principalTable: "TB_M_Position",
                        principalColumn: "PositionID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_M_Account",
                columns: table => new
                {
                    NIK = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_Account", x => x.NIK);
                    table.ForeignKey(
                        name: "FK_TB_M_Account_TB_M_Employee_NIK",
                        column: x => x.NIK,
                        principalTable: "TB_M_Employee",
                        principalColumn: "NIK",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_T_OvertimeData",
                columns: table => new
                {
                    OvertimeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NIK = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_T_OvertimeData", x => x.OvertimeID);
                    table.ForeignKey(
                        name: "FK_TB_T_OvertimeData_TB_M_Employee_NIK",
                        column: x => x.NIK,
                        principalTable: "TB_M_Employee",
                        principalColumn: "NIK",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_T_AccountRole",
                columns: table => new
                {
                    AccountNIK = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_T_AccountRole", x => new { x.AccountNIK, x.RoleID });
                    table.ForeignKey(
                        name: "FK_TB_T_AccountRole_TB_M_Account_AccountNIK",
                        column: x => x.AccountNIK,
                        principalTable: "TB_M_Account",
                        principalColumn: "NIK",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_T_AccountRole_TB_M_Role_RoleID",
                        column: x => x.RoleID,
                        principalTable: "TB_M_Role",
                        principalColumn: "RoleID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_T_OvertimeApplication",
                columns: table => new
                {
                    OvertimeApplicationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OvertimeID = table.Column<int>(type: "int", nullable: false),
                    SubmissionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OvertimeDay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StatusManager = table.Column<int>(type: "int", nullable: false),
                    StatusFinance = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_T_OvertimeApplication", x => x.OvertimeApplicationID);
                    table.ForeignKey(
                        name: "FK_TB_T_OvertimeApplication_TB_T_OvertimeData_OvertimeID",
                        column: x => x.OvertimeID,
                        principalTable: "TB_T_OvertimeData",
                        principalColumn: "OvertimeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_T_Activity",
                columns: table => new
                {
                    ActivityID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActivityDetails = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AdditionalSalary = table.Column<int>(type: "int", nullable: false),
                    OvertimeApplicationID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_T_Activity", x => x.ActivityID);
                    table.ForeignKey(
                        name: "FK_TB_T_Activity_TB_T_OvertimeApplication_OvertimeApplicationID",
                        column: x => x.OvertimeApplicationID,
                        principalTable: "TB_T_OvertimeApplication",
                        principalColumn: "OvertimeApplicationID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_M_Employee_ClientID",
                table: "TB_M_Employee",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_TB_M_Employee_DepartmentID",
                table: "TB_M_Employee",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_TB_M_Employee_PositionID",
                table: "TB_M_Employee",
                column: "PositionID");

            migrationBuilder.CreateIndex(
                name: "IX_TB_T_AccountRole_RoleID",
                table: "TB_T_AccountRole",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_TB_T_Activity_OvertimeApplicationID",
                table: "TB_T_Activity",
                column: "OvertimeApplicationID");

            migrationBuilder.CreateIndex(
                name: "IX_TB_T_OvertimeApplication_OvertimeID",
                table: "TB_T_OvertimeApplication",
                column: "OvertimeID");

            migrationBuilder.CreateIndex(
                name: "IX_TB_T_OvertimeData_NIK",
                table: "TB_T_OvertimeData",
                column: "NIK",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_T_AccountRole");

            migrationBuilder.DropTable(
                name: "TB_T_Activity");

            migrationBuilder.DropTable(
                name: "TB_M_Account");

            migrationBuilder.DropTable(
                name: "TB_M_Role");

            migrationBuilder.DropTable(
                name: "TB_T_OvertimeApplication");

            migrationBuilder.DropTable(
                name: "TB_T_OvertimeData");

            migrationBuilder.DropTable(
                name: "TB_M_Employee");

            migrationBuilder.DropTable(
                name: "TB_M_Client");

            migrationBuilder.DropTable(
                name: "TB_M_Department");

            migrationBuilder.DropTable(
                name: "TB_M_Position");
        }
    }
}
