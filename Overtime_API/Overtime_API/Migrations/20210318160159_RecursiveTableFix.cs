using Microsoft.EntityFrameworkCore.Migrations;

namespace Overtime_API.Migrations
{
    public partial class RecursiveTableFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ManagerNIK",
                table: "TB_M_Employee",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_M_Employee_ManagerNIK",
                table: "TB_M_Employee",
                column: "ManagerNIK");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_M_Employee_TB_M_Employee_ManagerNIK",
                table: "TB_M_Employee",
                column: "ManagerNIK",
                principalTable: "TB_M_Employee",
                principalColumn: "NIK",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_M_Employee_TB_M_Employee_ManagerNIK",
                table: "TB_M_Employee");

            migrationBuilder.DropIndex(
                name: "IX_TB_M_Employee_ManagerNIK",
                table: "TB_M_Employee");

            migrationBuilder.AlterColumn<string>(
                name: "ManagerNIK",
                table: "TB_M_Employee",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }
    }
}
