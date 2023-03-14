using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiClubMedv2.Migrations
{
    public partial class AjoutDesTablesSupplementairesPrLaBddA : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "t_e_client_clt",
                newName: "t_e_client_clt",
                newSchema: "clubmed");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "t_e_client_clt",
                schema: "clubmed",
                newName: "t_e_client_clt");
        }
    }
}
