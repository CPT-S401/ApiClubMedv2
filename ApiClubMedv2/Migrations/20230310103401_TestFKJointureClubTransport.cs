using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiClubMedv2.Migrations
{
    public partial class TestFKJointureClubTransport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdMultiMedia",
                schema: "clubmed",
                table: "t_j_clubmultimedia_cmt",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "t_j_clubtransport_ctr",
                schema: "clubmed",
                columns: table => new
                {
                    ctr_idclub = table.Column<int>(type: "integer", nullable: false),
                    ctr_idtransport = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_j_clubtransport_ctr", x => new { x.ctr_idclub, x.ctr_idtransport });
                    table.ForeignKey(
                        name: "fk_clb_ctr",
                        column: x => x.ctr_idclub,
                        principalSchema: "clubmed",
                        principalTable: "t_e_club_clb",
                        principalColumn: "clb_id");
                    table.ForeignKey(
                        name: "fk_cmb_ctr",
                        column: x => x.ctr_idtransport,
                        principalSchema: "clubmed",
                        principalTable: "t_e_transport_trp",
                        principalColumn: "trp_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_t_j_clubtransport_ctr_ctr_idtransport",
                schema: "clubmed",
                table: "t_j_clubtransport_ctr",
                column: "ctr_idtransport");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "t_j_clubtransport_ctr",
                schema: "clubmed");

            migrationBuilder.DropColumn(
                name: "IdMultiMedia",
                schema: "clubmed",
                table: "t_j_clubmultimedia_cmt");
        }
    }
}
