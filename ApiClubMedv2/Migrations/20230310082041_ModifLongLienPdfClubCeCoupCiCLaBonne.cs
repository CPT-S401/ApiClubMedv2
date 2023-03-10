using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiClubMedv2.Migrations
{
    public partial class ModifLongLienPdfClubCeCoupCiCLaBonne : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "t_e_multimedia_mtm",
                newName: "t_e_multimedia_mtm",
                newSchema: "clubmed");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "t_e_multimedia_mtm",
                schema: "clubmed",
                newName: "t_e_multimedia_mtm");
        }
    }
}
