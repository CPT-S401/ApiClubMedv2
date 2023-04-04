using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiClubMedv2.Migrations
{
    public partial class DeleteJointureCorrectionBd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "t_j_clubtypechambre_cth",
                schema: "clubmed");

            migrationBuilder.RenameColumn(
                name: "atm_idtypecaracteristique",
                schema: "clubmed",
                table: "t_j_activitemultimedia_atm",
                newName: "atm_idactivite");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "atm_idactivite",
                schema: "clubmed",
                table: "t_j_activitemultimedia_atm",
                newName: "atm_idtypecaracteristique");

            migrationBuilder.CreateTable(
                name: "t_j_clubtypechambre_cth",
                schema: "clubmed",
                columns: table => new
                {
                    cth_idclub = table.Column<int>(type: "integer", nullable: false),
                    cth_idtypechambre = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_j_clubtypechambre_cth", x => new { x.cth_idclub, x.cth_idtypechambre });
                    table.ForeignKey(
                        name: "fk_clb_cth",
                        column: x => x.cth_idclub,
                        principalSchema: "clubmed",
                        principalTable: "t_e_club_clb",
                        principalColumn: "clb_id");
                    table.ForeignKey(
                        name: "fk_tch_cth",
                        column: x => x.cth_idtypechambre,
                        principalSchema: "clubmed",
                        principalTable: "t_e_typechambre_tch",
                        principalColumn: "tch_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_t_j_clubtypechambre_cth_cth_idtypechambre",
                schema: "clubmed",
                table: "t_j_clubtypechambre_cth",
                column: "cth_idtypechambre");
        }
    }
}
