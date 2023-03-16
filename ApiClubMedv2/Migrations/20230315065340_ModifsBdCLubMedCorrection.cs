using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiClubMedv2.Migrations
{
    public partial class ModifsBdCLubMedCorrection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "rmt_idmultimedia",
                schema: "clubmed",
                table: "t_j_villecodepostal_vcp",
                newName: "vcp_idcodepostal");

            migrationBuilder.RenameColumn(
                name: "rmt_idrestaurant",
                schema: "clubmed",
                table: "t_j_villecodepostal_vcp",
                newName: "vcp_idville");

            migrationBuilder.RenameIndex(
                name: "IX_t_j_villecodepostal_vcp_rmt_idmultimedia",
                schema: "clubmed",
                table: "t_j_villecodepostal_vcp",
                newName: "IX_t_j_villecodepostal_vcp_vcp_idcodepostal");

            migrationBuilder.AlterColumn<string>(
                name: "vil_nom",
                schema: "clubmed",
                table: "t_e_ville_vil",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "vcp_idcodepostal",
                schema: "clubmed",
                table: "t_j_villecodepostal_vcp",
                newName: "rmt_idmultimedia");

            migrationBuilder.RenameColumn(
                name: "vcp_idville",
                schema: "clubmed",
                table: "t_j_villecodepostal_vcp",
                newName: "rmt_idrestaurant");

            migrationBuilder.RenameIndex(
                name: "IX_t_j_villecodepostal_vcp_vcp_idcodepostal",
                schema: "clubmed",
                table: "t_j_villecodepostal_vcp",
                newName: "IX_t_j_villecodepostal_vcp_rmt_idmultimedia");

            migrationBuilder.AlterColumn<string>(
                name: "vil_nom",
                schema: "clubmed",
                table: "t_e_ville_vil",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);
        }
    }
}
