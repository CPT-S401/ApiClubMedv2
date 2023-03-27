using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiClubMedv2.Migrations
{
    public partial class ihopethisworks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_t_e_activiteenfant_ace_t_e_activite_act_act_id",
                schema: "clubmed",
                table: "t_e_activiteenfant_ace");

            migrationBuilder.DropForeignKey(
                name: "fk_ace_cae",
                schema: "clubmed",
                table: "t_j_clubactiviteenfant_cae");

            migrationBuilder.DropIndex(
                name: "IX_t_j_clubactiviteenfant_cae_cae_idactiviteenfant",
                schema: "clubmed",
                table: "t_j_clubactiviteenfant_cae");

            migrationBuilder.AddForeignKey(
                name: "fk_act_ace",
                schema: "clubmed",
                table: "t_e_activiteenfant_ace",
                column: "act_id",
                principalSchema: "clubmed",
                principalTable: "t_e_activite_act",
                principalColumn: "act_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_act_ace",
                schema: "clubmed",
                table: "t_e_activiteenfant_ace");

            migrationBuilder.CreateIndex(
                name: "IX_t_j_clubactiviteenfant_cae_cae_idactiviteenfant",
                schema: "clubmed",
                table: "t_j_clubactiviteenfant_cae",
                column: "cae_idactiviteenfant");

            migrationBuilder.AddForeignKey(
                name: "FK_t_e_activiteenfant_ace_t_e_activite_act_act_id",
                schema: "clubmed",
                table: "t_e_activiteenfant_ace",
                column: "act_id",
                principalSchema: "clubmed",
                principalTable: "t_e_activite_act",
                principalColumn: "act_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_ace_cae",
                schema: "clubmed",
                table: "t_j_clubactiviteenfant_cae",
                column: "cae_idactiviteenfant",
                principalSchema: "clubmed",
                principalTable: "t_e_activiteenfant_ace",
                principalColumn: "act_id");
        }
    }
}
