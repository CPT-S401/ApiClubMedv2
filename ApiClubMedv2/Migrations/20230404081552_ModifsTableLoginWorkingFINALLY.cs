using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiClubMedv2.Migrations
{
    public partial class ModifsTableLoginWorkingFINALLY : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "tcm_idmultimedia",
                schema: "clubmed",
                table: "t_j_typeactivitemultimedia_tam",
                newName: "tam_idmultimedia");

            migrationBuilder.RenameColumn(
                name: "tcm_idtypecaracteristique",
                schema: "clubmed",
                table: "t_j_typeactivitemultimedia_tam",
                newName: "tam_idtypeactivite");

            migrationBuilder.RenameIndex(
                name: "IX_t_j_typeactivitemultimedia_tam_tcm_idmultimedia",
                schema: "clubmed",
                table: "t_j_typeactivitemultimedia_tam",
                newName: "IX_t_j_typeactivitemultimedia_tam_tam_idmultimedia");

            migrationBuilder.RenameColumn(
                name: "dmt_idclub",
                schema: "clubmed",
                table: "t_j_domainemultimedia_dmt",
                newName: "dmt_iddomaineskiable");

            migrationBuilder.AlterColumn<string>(
                name: "ctq_nom",
                schema: "clubmed",
                table: "t_e_caracteristique_ctq",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "tam_idmultimedia",
                schema: "clubmed",
                table: "t_j_typeactivitemultimedia_tam",
                newName: "tcm_idmultimedia");

            migrationBuilder.RenameColumn(
                name: "tam_idtypeactivite",
                schema: "clubmed",
                table: "t_j_typeactivitemultimedia_tam",
                newName: "tcm_idtypecaracteristique");

            migrationBuilder.RenameIndex(
                name: "IX_t_j_typeactivitemultimedia_tam_tam_idmultimedia",
                schema: "clubmed",
                table: "t_j_typeactivitemultimedia_tam",
                newName: "IX_t_j_typeactivitemultimedia_tam_tcm_idmultimedia");

            migrationBuilder.RenameColumn(
                name: "dmt_iddomaineskiable",
                schema: "clubmed",
                table: "t_j_domainemultimedia_dmt",
                newName: "dmt_idclub");

            migrationBuilder.AlterColumn<string>(
                name: "ctq_nom",
                schema: "clubmed",
                table: "t_e_caracteristique_ctq",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);
        }
    }
}
