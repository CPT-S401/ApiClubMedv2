using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiClubMedv2.Migrations
{
    public partial class TestFKJointure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "mtm_idclub",
                schema: "clubmed",
                table: "t_e_multimedia_mtm");

            migrationBuilder.DropColumn(
                name: "mtm_idrestauration",
                schema: "clubmed",
                table: "t_e_multimedia_mtm");

            migrationBuilder.CreateTable(
                name: "t_j_clubmultimedia_cmt",
                schema: "clubmed",
                columns: table => new
                {
                    cmt_idclub = table.Column<int>(type: "integer", nullable: false),
                    cmt_idmultimedia = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_j_clubmultimedia_cmt", x => new { x.cmt_idclub, x.cmt_idmultimedia });
                    table.ForeignKey(
                        name: "fk_clb_cmt",
                        column: x => x.cmt_idclub,
                        principalSchema: "clubmed",
                        principalTable: "t_e_club_clb",
                        principalColumn: "clb_id");
                    table.ForeignKey(
                        name: "fk_mtm_cmt",
                        column: x => x.cmt_idmultimedia,
                        principalSchema: "clubmed",
                        principalTable: "t_e_multimedia_mtm",
                        principalColumn: "mtm_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_t_j_clubmultimedia_cmt_cmt_idmultimedia",
                schema: "clubmed",
                table: "t_j_clubmultimedia_cmt",
                column: "cmt_idmultimedia");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "t_j_clubmultimedia_cmt",
                schema: "clubmed");

            migrationBuilder.AddColumn<int>(
                name: "mtm_idclub",
                schema: "clubmed",
                table: "t_e_multimedia_mtm",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "mtm_idrestauration",
                schema: "clubmed",
                table: "t_e_multimedia_mtm",
                type: "integer",
                nullable: true);
        }
    }
}
