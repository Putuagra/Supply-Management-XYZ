using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Supply_Management_XYZ.Server.Migrations
{
    public partial class add_account_vendor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_m_accounts_tb_m_vendors_guid",
                table: "tb_m_accounts");

            migrationBuilder.CreateTable(
                name: "tb_m_account_vendors",
                columns: table => new
                {
                    guid = table.Column<Guid>(type: "CHAR(36)", nullable: false, collation: "ascii_general_ci"),
                    password = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    modified_date = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_account_vendors", x => x.guid);
                    table.ForeignKey(
                        name: "FK_tb_m_account_vendors_tb_m_vendors_guid",
                        column: x => x.guid,
                        principalTable: "tb_m_vendors",
                        principalColumn: "guid",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_m_account_vendors");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_m_accounts_tb_m_vendors_guid",
                table: "tb_m_accounts",
                column: "guid",
                principalTable: "tb_m_vendors",
                principalColumn: "guid",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
