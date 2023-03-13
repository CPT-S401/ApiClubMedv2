using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ApiClubMedv2.Migrations
{
    public partial class AjoutTablesSupplemntairesBdClubMedS3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "t_j_clubtypeclub_ctc",
                schema: "clubmed",
                columns: table => new
                {
                    ctc_idclub = table.Column<int>(type: "integer", nullable: false),
                    ctc_idtypeclub = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_j_clubtypeclub_ctc", x => new { x.ctc_idclub, x.ctc_idtypeclub });
                    table.ForeignKey(
                        name: "fk_clb_ctc",
                        column: x => x.ctc_idclub,
                        principalSchema: "clubmed",
                        principalTable: "t_e_club_clb",
                        principalColumn: "clb_id");
                    table.ForeignKey(
                        name: "fk_tcl_ctc",
                        column: x => x.ctc_idtypeclub,
                        principalSchema: "clubmed",
                        principalTable: "t_e_typeclub_tcl",
                        principalColumn: "tcl_id");
                });

            migrationBuilder.CreateTable(
                name: "TypesChambre",
                columns: table => new
                {
                    tch_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    tch_idclub = table.Column<int>(type: "integer", nullable: false),
                    tch_nom = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    tch_description = table.Column<string>(type: "text", nullable: true),
                    tch_prix = table.Column<decimal>(type: "numeric(7,2)", nullable: false),
                    tch_surface = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypesChambre", x => x.tch_id);
                    table.CheckConstraint("ck_tch_prix", "tch_prix > 0");
                });

            migrationBuilder.CreateTable(
                name: "t_e_reservation_rea",
                schema: "clubmed",
                columns: table => new
                {
                    rea_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    rea_idclient = table.Column<int>(type: "integer", nullable: false),
                    rea_idtransport = table.Column<int>(type: "integer", nullable: true),
                    rea_idclub = table.Column<int>(type: "integer", nullable: false),
                    rea_idtypechambre = table.Column<int>(type: "integer", nullable: false),
                    rea_datedebut = table.Column<DateTime>(type: "date", nullable: false),
                    rea_datefin = table.Column<DateTime>(type: "date", nullable: false),
                    rea_date = table.Column<DateTime>(type: "date", nullable: false),
                    fk_trp_rea = table.Column<int>(type: "integer", nullable: true),
                    fk_clb_rea = table.Column<int>(type: "integer", nullable: false),
                    fk_tch_rea = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_e_reservation_rea", x => x.rea_id);
                    table.ForeignKey(
                        name: "FK_t_e_reservation_rea_t_e_club_clb_fk_clb_rea",
                        column: x => x.fk_clb_rea,
                        principalSchema: "clubmed",
                        principalTable: "t_e_club_clb",
                        principalColumn: "clb_id");
                    table.ForeignKey(
                        name: "FK_t_e_reservation_rea_t_e_transport_trp_fk_trp_rea",
                        column: x => x.fk_trp_rea,
                        principalSchema: "clubmed",
                        principalTable: "t_e_transport_trp",
                        principalColumn: "trp_id");
                    table.ForeignKey(
                        name: "FK_t_e_reservation_rea_TypesChambre_fk_tch_rea",
                        column: x => x.fk_tch_rea,
                        principalTable: "TypesChambre",
                        principalColumn: "tch_id");
                });

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
                        principalTable: "TypesChambre",
                        principalColumn: "tch_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_t_e_reservation_rea_fk_clb_rea",
                schema: "clubmed",
                table: "t_e_reservation_rea",
                column: "fk_clb_rea");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_reservation_rea_fk_tch_rea",
                schema: "clubmed",
                table: "t_e_reservation_rea",
                column: "fk_tch_rea");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_reservation_rea_fk_trp_rea",
                schema: "clubmed",
                table: "t_e_reservation_rea",
                column: "fk_trp_rea");

            migrationBuilder.CreateIndex(
                name: "IX_t_j_clubtypechambre_cth_cth_idtypechambre",
                schema: "clubmed",
                table: "t_j_clubtypechambre_cth",
                column: "cth_idtypechambre");

            migrationBuilder.CreateIndex(
                name: "IX_t_j_clubtypeclub_ctc_ctc_idtypeclub",
                schema: "clubmed",
                table: "t_j_clubtypeclub_ctc",
                column: "ctc_idtypeclub");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "t_e_reservation_rea",
                schema: "clubmed");

            migrationBuilder.DropTable(
                name: "t_j_clubtypechambre_cth",
                schema: "clubmed");

            migrationBuilder.DropTable(
                name: "t_j_clubtypeclub_ctc",
                schema: "clubmed");

            migrationBuilder.DropTable(
                name: "TypesChambre");
        }
    }
}
