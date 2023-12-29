using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Supply_Management_XYZ.Server.Migrations
{
    public partial class add_is_admin_approve : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "is_approve",
                table: "tb_m_vendors",
                newName: "is_manager_approve");

            migrationBuilder.AddColumn<bool>(
                name: "is_admin_approve",
                table: "tb_m_vendors",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "is_admin_approve",
                table: "tb_m_vendors");

            migrationBuilder.RenameColumn(
                name: "is_manager_approve",
                table: "tb_m_vendors",
                newName: "is_approve");
        }
    }
}
