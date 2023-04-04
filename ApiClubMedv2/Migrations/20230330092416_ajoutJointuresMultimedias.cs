using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ApiClubMedv2.Migrations
{
    public partial class ajoutJointuresMultimedias : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ctq_lienicon",
                schema: "clubmed",
                table: "t_e_caracteristique_ctq");

            migrationBuilder.AddColumn<int>(
                name: "ctq_idtypecaracteristique",
                schema: "clubmed",
                table: "t_e_caracteristique_ctq",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "t_e_typecaracteristique_tct",
                schema: "clubmed",
                columns: table => new
                {
                    ctq_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ctq_nom = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_e_typecaracteristique_tct", x => x.ctq_id);
                });

            migrationBuilder.CreateTable(
                name: "t_j_activitemultimedia_atm",
                schema: "clubmed",
                columns: table => new
                {
                    atm_idtypecaracteristique = table.Column<int>(type: "integer", nullable: false),
                    atm_idmultimedia = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_j_activitemultimedia_atm", x => new { x.atm_idtypecaracteristique, x.atm_idmultimedia });
                    table.ForeignKey(
                        name: "fk_act_atm",
                        column: x => x.atm_idtypecaracteristique,
                        principalSchema: "clubmed",
                        principalTable: "t_e_activite_act",
                        principalColumn: "act_id");
                    table.ForeignKey(
                        name: "fk_mlm_atm",
                        column: x => x.atm_idmultimedia,
                        principalSchema: "clubmed",
                        principalTable: "t_e_multimedia_mtm",
                        principalColumn: "mtm_id");
                });

            migrationBuilder.CreateTable(
                name: "t_j_caracteristiquemultimedia_cmt",
                schema: "clubmed",
                columns: table => new
                {
                    cmt_idcaracteristique = table.Column<int>(type: "integer", nullable: false),
                    cmt_idmultimedia = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_j_caracteristiquemultimedia_cmt", x => new { x.cmt_idcaracteristique, x.cmt_idmultimedia });
                    table.ForeignKey(
                        name: "fk_mlm_cmt",
                        column: x => x.cmt_idmultimedia,
                        principalSchema: "clubmed",
                        principalTable: "t_e_multimedia_mtm",
                        principalColumn: "mtm_id");
                    table.ForeignKey(
                        name: "fk_tct_cmt",
                        column: x => x.cmt_idcaracteristique,
                        principalSchema: "clubmed",
                        principalTable: "t_e_caracteristique_ctq",
                        principalColumn: "ctq_id");
                });

            migrationBuilder.CreateTable(
                name: "t_j_domainemultimedia_dmt",
                schema: "clubmed",
                columns: table => new
                {
                    dmt_idclub = table.Column<int>(type: "integer", nullable: false),
                    dmt_idmultimedia = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_j_domainemultimedia_dmt", x => new { x.dmt_idclub, x.dmt_idmultimedia });
                    table.ForeignKey(
                        name: "fk_mlm_dmt",
                        column: x => x.dmt_idmultimedia,
                        principalSchema: "clubmed",
                        principalTable: "t_e_multimedia_mtm",
                        principalColumn: "mtm_id");
                    table.ForeignKey(
                        name: "fk_tct_dmt",
                        column: x => x.dmt_idclub,
                        principalSchema: "clubmed",
                        principalTable: "t_e_domaineskiable_dsk",
                        principalColumn: "dsk_id");
                });

            migrationBuilder.CreateTable(
                name: "t_j_typeactivitemultimedia_tam",
                schema: "clubmed",
                columns: table => new
                {
                    tcm_idtypecaracteristique = table.Column<int>(type: "integer", nullable: false),
                    tcm_idmultimedia = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_j_typeactivitemultimedia_tam", x => new { x.tcm_idtypecaracteristique, x.tcm_idmultimedia });
                    table.ForeignKey(
                        name: "fk_mlm_tam",
                        column: x => x.tcm_idmultimedia,
                        principalSchema: "clubmed",
                        principalTable: "t_e_multimedia_mtm",
                        principalColumn: "mtm_id");
                    table.ForeignKey(
                        name: "fk_tac_tam",
                        column: x => x.tcm_idtypecaracteristique,
                        principalSchema: "clubmed",
                        principalTable: "t_e_typeactivite_tac",
                        principalColumn: "tac_id");
                });

            migrationBuilder.CreateTable(
                name: "t_j_typechambremultimedia_thm",
                schema: "clubmed",
                columns: table => new
                {
                    thm_idtypechambre = table.Column<int>(type: "integer", nullable: false),
                    thm_idmultimedia = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_j_typechambremultimedia_thm", x => new { x.thm_idtypechambre, x.thm_idmultimedia });
                    table.ForeignKey(
                        name: "fk_mlm_thm",
                        column: x => x.thm_idmultimedia,
                        principalSchema: "clubmed",
                        principalTable: "t_e_multimedia_mtm",
                        principalColumn: "mtm_id");
                    table.ForeignKey(
                        name: "fk_tch_thm",
                        column: x => x.thm_idtypechambre,
                        principalSchema: "clubmed",
                        principalTable: "t_e_typechambre_tch",
                        principalColumn: "tch_id");
                });

            migrationBuilder.CreateTable(
                name: "t_j_typecaracteristiquemultimedia_tcm",
                schema: "clubmed",
                columns: table => new
                {
                    tcm_idtypecaracteristique = table.Column<int>(type: "integer", nullable: false),
                    tcm_idmultimedia = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_j_typecaracteristiquemultimedia_tcm", x => new { x.tcm_idtypecaracteristique, x.tcm_idmultimedia });
                    table.ForeignKey(
                        name: "fk_mlm_tcm",
                        column: x => x.tcm_idmultimedia,
                        principalSchema: "clubmed",
                        principalTable: "t_e_multimedia_mtm",
                        principalColumn: "mtm_id");
                    table.ForeignKey(
                        name: "fk_tct_tcm",
                        column: x => x.tcm_idtypecaracteristique,
                        principalSchema: "clubmed",
                        principalTable: "t_e_typecaracteristique_tct",
                        principalColumn: "ctq_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_t_e_caracteristique_ctq_ctq_idtypecaracteristique",
                schema: "clubmed",
                table: "t_e_caracteristique_ctq",
                column: "ctq_idtypecaracteristique");

            migrationBuilder.CreateIndex(
                name: "IX_t_j_activitemultimedia_atm_atm_idmultimedia",
                schema: "clubmed",
                table: "t_j_activitemultimedia_atm",
                column: "atm_idmultimedia");

            migrationBuilder.CreateIndex(
                name: "IX_t_j_caracteristiquemultimedia_cmt_cmt_idmultimedia",
                schema: "clubmed",
                table: "t_j_caracteristiquemultimedia_cmt",
                column: "cmt_idmultimedia");

            migrationBuilder.CreateIndex(
                name: "IX_t_j_domainemultimedia_dmt_dmt_idmultimedia",
                schema: "clubmed",
                table: "t_j_domainemultimedia_dmt",
                column: "dmt_idmultimedia");

            migrationBuilder.CreateIndex(
                name: "IX_t_j_typeactivitemultimedia_tam_tcm_idmultimedia",
                schema: "clubmed",
                table: "t_j_typeactivitemultimedia_tam",
                column: "tcm_idmultimedia");

            migrationBuilder.CreateIndex(
                name: "IX_t_j_typecaracteristiquemultimedia_tcm_tcm_idmultimedia",
                schema: "clubmed",
                table: "t_j_typecaracteristiquemultimedia_tcm",
                column: "tcm_idmultimedia");

            migrationBuilder.CreateIndex(
                name: "IX_t_j_typechambremultimedia_thm_thm_idmultimedia",
                schema: "clubmed",
                table: "t_j_typechambremultimedia_thm",
                column: "thm_idmultimedia");

            migrationBuilder.AddForeignKey(
                name: "fk_ctq_tct",
                schema: "clubmed",
                table: "t_e_caracteristique_ctq",
                column: "ctq_idtypecaracteristique",
                principalSchema: "clubmed",
                principalTable: "t_e_typecaracteristique_tct",
                principalColumn: "ctq_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_ctq_tct",
                schema: "clubmed",
                table: "t_e_caracteristique_ctq");

            migrationBuilder.DropTable(
                name: "t_j_activitemultimedia_atm",
                schema: "clubmed");

            migrationBuilder.DropTable(
                name: "t_j_caracteristiquemultimedia_cmt",
                schema: "clubmed");

            migrationBuilder.DropTable(
                name: "t_j_domainemultimedia_dmt",
                schema: "clubmed");

            migrationBuilder.DropTable(
                name: "t_j_typeactivitemultimedia_tam",
                schema: "clubmed");

            migrationBuilder.DropTable(
                name: "t_j_typecaracteristiquemultimedia_tcm",
                schema: "clubmed");

            migrationBuilder.DropTable(
                name: "t_j_typechambremultimedia_thm",
                schema: "clubmed");

            migrationBuilder.DropTable(
                name: "t_e_typecaracteristique_tct",
                schema: "clubmed");

            migrationBuilder.DropIndex(
                name: "IX_t_e_caracteristique_ctq_ctq_idtypecaracteristique",
                schema: "clubmed",
                table: "t_e_caracteristique_ctq");

            migrationBuilder.DropColumn(
                name: "ctq_idtypecaracteristique",
                schema: "clubmed",
                table: "t_e_caracteristique_ctq");

            migrationBuilder.AddColumn<string>(
                name: "ctq_lienicon",
                schema: "clubmed",
                table: "t_e_caracteristique_ctq",
                type: "varchar(255)",
                maxLength: 255,
                nullable: true);
        }
    }
}
