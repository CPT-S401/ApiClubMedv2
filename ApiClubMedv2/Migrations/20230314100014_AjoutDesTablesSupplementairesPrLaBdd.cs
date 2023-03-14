using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ApiClubMedv2.Migrations
{
    public partial class AjoutDesTablesSupplementairesPrLaBdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_t_e_reservation_rea_t_e_club_clb_fk_clb_rea",
                schema: "clubmed",
                table: "t_e_reservation_rea");

            migrationBuilder.DropForeignKey(
                name: "FK_t_e_reservation_rea_t_e_transport_trp_fk_trp_rea",
                schema: "clubmed",
                table: "t_e_reservation_rea");

            migrationBuilder.DropForeignKey(
                name: "FK_t_e_reservation_rea_TypesChambre_fk_tch_rea",
                schema: "clubmed",
                table: "t_e_reservation_rea");

            migrationBuilder.DropIndex(
                name: "IX_t_e_reservation_rea_fk_clb_rea",
                schema: "clubmed",
                table: "t_e_reservation_rea");

            migrationBuilder.DropIndex(
                name: "IX_t_e_reservation_rea_fk_tch_rea",
                schema: "clubmed",
                table: "t_e_reservation_rea");

            migrationBuilder.DropIndex(
                name: "IX_t_e_reservation_rea_fk_trp_rea",
                schema: "clubmed",
                table: "t_e_reservation_rea");

            migrationBuilder.DropColumn(
                name: "fk_clb_rea",
                schema: "clubmed",
                table: "t_e_reservation_rea");

            migrationBuilder.DropColumn(
                name: "fk_tch_rea",
                schema: "clubmed",
                table: "t_e_reservation_rea");

            migrationBuilder.DropColumn(
                name: "fk_trp_rea",
                schema: "clubmed",
                table: "t_e_reservation_rea");

            migrationBuilder.CreateTable(
                name: "t_e_client_clt",
                columns: table => new
                {
                    clt_idclient = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    clt_genreclient = table.Column<string>(type: "char(10)", maxLength: 10, nullable: false),
                    clt_prenomclient = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    clt_nomclient = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    clt_datenaissance = table.Column<DateTime>(type: "date", nullable: false),
                    clt_email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    clt_mobile = table.Column<string>(type: "char(10)", maxLength: 10, nullable: false),
                    clt_password = table.Column<string>(type: "text", nullable: false),
                    clt_numrue = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    clt_nomrue = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    clt_idcodepostal = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_e_client_clt", x => x.clt_idclient);
                    table.ForeignKey(
                        name: "FK_t_e_client_clt_t_e_codepostal_cpl_clt_idcodepostal",
                        column: x => x.clt_idcodepostal,
                        principalSchema: "clubmed",
                        principalTable: "t_e_codepostal_cpl",
                        principalColumn: "cpl_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "t_e_avis_avi",
                schema: "clubmed",
                columns: table => new
                {
                    avi_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    avi_idclient = table.Column<int>(type: "integer", nullable: false),
                    avi_idclub = table.Column<int>(type: "integer", nullable: false),
                    avi_note = table.Column<int>(type: "integer", nullable: false),
                    avi_commentaire = table.Column<string>(type: "text", nullable: true),
                    avi_dateenvoi = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_e_avis_avi", x => x.avi_id);
                    table.ForeignKey(
                        name: "fk_clb_avi",
                        column: x => x.avi_idclient,
                        principalSchema: "clubmed",
                        principalTable: "t_e_club_clb",
                        principalColumn: "clb_id");
                    table.ForeignKey(
                        name: "fk_clt_avi",
                        column: x => x.avi_idclient,
                        principalTable: "t_e_client_clt",
                        principalColumn: "clt_idclient");
                });

            migrationBuilder.CreateTable(
                name: "t_j_avismultimedia_amt",
                schema: "clubmed",
                columns: table => new
                {
                    amt_idavis = table.Column<int>(type: "integer", nullable: false),
                    amt_idmultimedia = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_j_avismultimedia_amt", x => new { x.amt_idavis, x.amt_idmultimedia });
                    table.ForeignKey(
                        name: "fk_avi_amt",
                        column: x => x.amt_idavis,
                        principalSchema: "clubmed",
                        principalTable: "t_e_avis_avi",
                        principalColumn: "avi_id");
                    table.ForeignKey(
                        name: "fk_mtm_amt",
                        column: x => x.amt_idmultimedia,
                        principalSchema: "clubmed",
                        principalTable: "t_e_multimedia_mtm",
                        principalColumn: "mtm_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_t_e_reservation_rea_rea_idclient",
                schema: "clubmed",
                table: "t_e_reservation_rea",
                column: "rea_idclient");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_reservation_rea_rea_idclub",
                schema: "clubmed",
                table: "t_e_reservation_rea",
                column: "rea_idclub");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_reservation_rea_rea_idtransport",
                schema: "clubmed",
                table: "t_e_reservation_rea",
                column: "rea_idtransport");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_reservation_rea_rea_idtypechambre",
                schema: "clubmed",
                table: "t_e_reservation_rea",
                column: "rea_idtypechambre");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_avis_avi_avi_idclient",
                schema: "clubmed",
                table: "t_e_avis_avi",
                column: "avi_idclient");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_client_clt_clt_email",
                table: "t_e_client_clt",
                column: "clt_email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_t_e_client_clt_clt_idcodepostal",
                table: "t_e_client_clt",
                column: "clt_idcodepostal");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_client_clt_clt_mobile",
                table: "t_e_client_clt",
                column: "clt_mobile",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_t_j_avismultimedia_amt_amt_idmultimedia",
                schema: "clubmed",
                table: "t_j_avismultimedia_amt",
                column: "amt_idmultimedia");

            migrationBuilder.AddForeignKey(
                name: "fk_clb_rea",
                schema: "clubmed",
                table: "t_e_reservation_rea",
                column: "rea_idclub",
                principalSchema: "clubmed",
                principalTable: "t_e_club_clb",
                principalColumn: "clb_id");

            migrationBuilder.AddForeignKey(
                name: "fk_clt_rea",
                schema: "clubmed",
                table: "t_e_reservation_rea",
                column: "rea_idclient",
                principalTable: "t_e_client_clt",
                principalColumn: "clt_idclient");

            migrationBuilder.AddForeignKey(
                name: "fk_tch_rea",
                schema: "clubmed",
                table: "t_e_reservation_rea",
                column: "rea_idtypechambre",
                principalTable: "TypesChambre",
                principalColumn: "tch_id");

            migrationBuilder.AddForeignKey(
                name: "fk_trp_rea",
                schema: "clubmed",
                table: "t_e_reservation_rea",
                column: "rea_idtransport",
                principalSchema: "clubmed",
                principalTable: "t_e_transport_trp",
                principalColumn: "trp_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_clb_rea",
                schema: "clubmed",
                table: "t_e_reservation_rea");

            migrationBuilder.DropForeignKey(
                name: "fk_clt_rea",
                schema: "clubmed",
                table: "t_e_reservation_rea");

            migrationBuilder.DropForeignKey(
                name: "fk_tch_rea",
                schema: "clubmed",
                table: "t_e_reservation_rea");

            migrationBuilder.DropForeignKey(
                name: "fk_trp_rea",
                schema: "clubmed",
                table: "t_e_reservation_rea");

            migrationBuilder.DropTable(
                name: "t_j_avismultimedia_amt",
                schema: "clubmed");

            migrationBuilder.DropTable(
                name: "t_e_avis_avi",
                schema: "clubmed");

            migrationBuilder.DropTable(
                name: "t_e_client_clt");

            migrationBuilder.DropIndex(
                name: "IX_t_e_reservation_rea_rea_idclient",
                schema: "clubmed",
                table: "t_e_reservation_rea");

            migrationBuilder.DropIndex(
                name: "IX_t_e_reservation_rea_rea_idclub",
                schema: "clubmed",
                table: "t_e_reservation_rea");

            migrationBuilder.DropIndex(
                name: "IX_t_e_reservation_rea_rea_idtransport",
                schema: "clubmed",
                table: "t_e_reservation_rea");

            migrationBuilder.DropIndex(
                name: "IX_t_e_reservation_rea_rea_idtypechambre",
                schema: "clubmed",
                table: "t_e_reservation_rea");

            migrationBuilder.AddColumn<int>(
                name: "fk_clb_rea",
                schema: "clubmed",
                table: "t_e_reservation_rea",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "fk_tch_rea",
                schema: "clubmed",
                table: "t_e_reservation_rea",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "fk_trp_rea",
                schema: "clubmed",
                table: "t_e_reservation_rea",
                type: "integer",
                nullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_t_e_reservation_rea_t_e_club_clb_fk_clb_rea",
                schema: "clubmed",
                table: "t_e_reservation_rea",
                column: "fk_clb_rea",
                principalSchema: "clubmed",
                principalTable: "t_e_club_clb",
                principalColumn: "clb_id");

            migrationBuilder.AddForeignKey(
                name: "FK_t_e_reservation_rea_t_e_transport_trp_fk_trp_rea",
                schema: "clubmed",
                table: "t_e_reservation_rea",
                column: "fk_trp_rea",
                principalSchema: "clubmed",
                principalTable: "t_e_transport_trp",
                principalColumn: "trp_id");

            migrationBuilder.AddForeignKey(
                name: "FK_t_e_reservation_rea_TypesChambre_fk_tch_rea",
                schema: "clubmed",
                table: "t_e_reservation_rea",
                column: "fk_tch_rea",
                principalTable: "TypesChambre",
                principalColumn: "tch_id");
        }
    }
}
