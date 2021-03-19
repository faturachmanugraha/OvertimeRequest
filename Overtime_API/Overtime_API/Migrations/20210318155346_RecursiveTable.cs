using Microsoft.EntityFrameworkCore.Migrations;

namespace Overtime_API.Migrations
{
    public partial class RecursiveTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ManagerNIK",
                table: "TB_M_Employee",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ManagerNIK",
                table: "TB_M_Employee");
        }
    }
}
