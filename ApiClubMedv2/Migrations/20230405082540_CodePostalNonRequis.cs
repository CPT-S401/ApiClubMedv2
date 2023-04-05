using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiClubMedv2.Migrations
{
    public partial class CodePostalNonRequis : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_t_e_client_clt_t_e_codepostal_cpl_clt_idcodepostal",
                schema: "clubmed",
                table: "t_e_client_clt");

            migrationBuilder.AlterColumn<int>(
                name: "clt_idcodepostal",
                schema: "clubmed",
                table: "t_e_client_clt",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_t_e_client_clt_t_e_codepostal_cpl_clt_idcodepostal",
                schema: "clubmed",
                table: "t_e_client_clt",
                column: "clt_idcodepostal",
                principalSchema: "clubmed",
                principalTable: "t_e_codepostal_cpl",
                principalColumn: "cpl_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_t_e_client_clt_t_e_codepostal_cpl_clt_idcodepostal",
                schema: "clubmed",
                table: "t_e_client_clt");

            migrationBuilder.AlterColumn<int>(
                name: "clt_idcodepostal",
                schema: "clubmed",
                table: "t_e_client_clt",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_t_e_client_clt_t_e_codepostal_cpl_clt_idcodepostal",
                schema: "clubmed",
                table: "t_e_client_clt",
                column: "clt_idcodepostal",
                principalSchema: "clubmed",
                principalTable: "t_e_codepostal_cpl",
                principalColumn: "cpl_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
