using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ApiClubMedv2.Migrations
{
    public partial class CreationBdClubMedS3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "clubmed");

            migrationBuilder.CreateTable(
                name: "t_e_caracteristique_ctq",
                schema: "clubmed",
                columns: table => new
                {
                    ctq_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ctq_nom = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    ctq_lienicon = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_e_caracteristique_ctq", x => x.ctq_id);
                });

            migrationBuilder.CreateTable(
                name: "t_e_codepostal_cpl",
                schema: "clubmed",
                columns: table => new
                {
                    cpl_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    cpl_nom = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_e_codepostal_cpl", x => x.cpl_id);
                });

            migrationBuilder.CreateTable(
                name: "t_e_cookie_cok",
                schema: "clubmed",
                columns: table => new
                {
                    cok_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    cok_nom = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    cok_description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_e_cookie_cok", x => x.cok_id);
                });

            migrationBuilder.CreateTable(
                name: "t_e_domaineskiable_dsk",
                schema: "clubmed",
                columns: table => new
                {
                    dsk_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    dsk_nom = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    dsk_description = table.Column<string>(type: "text", nullable: true),
                    dsk_nomstation = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    dsk_altitudebasse = table.Column<decimal>(type: "numeric(6,2)", nullable: true),
                    dsk_altitudehaute = table.Column<decimal>(type: "numeric(6,2)", nullable: true),
                    dsk_longueurpistes = table.Column<decimal>(type: "numeric(3,0)", nullable: true),
                    dsk_nbpistes = table.Column<decimal>(type: "numeric(3,0)", nullable: true),
                    dsk_infoski = table.Column<string>(type: "varchar(200)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_e_domaineskiable_dsk", x => x.dsk_id);
                    table.CheckConstraint("ck_dsk_altbasse_althaute", "dsk_altitudebasse > 0 and dsk_altitudehaute > dsk_altitudebasse");
                    table.CheckConstraint("ck_dsk_longueurpistes", "dsk_longueurpistes > 0");
                    table.CheckConstraint("ck_dsk_nombrepistes", "dsk_nbpistes > 0");
                });

            migrationBuilder.CreateTable(
                name: "t_e_localisation_loc",
                schema: "clubmed",
                columns: table => new
                {
                    loc_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    loc_nom = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_e_localisation_loc", x => x.loc_id);
                });

            migrationBuilder.CreateTable(
                name: "t_e_multimedia_mtm",
                schema: "clubmed",
                columns: table => new
                {
                    mtm_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    mtm_nom = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    mtm_description = table.Column<string>(type: "text", nullable: true),
                    mtm_lien = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_e_multimedia_mtm", x => x.mtm_id);
                });

            migrationBuilder.CreateTable(
                name: "t_e_pays_pay",
                schema: "clubmed",
                columns: table => new
                {
                    pay_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    pay_nom = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_e_pays_pay", x => x.pay_id);
                });

            migrationBuilder.CreateTable(
                name: "t_e_transport_trp",
                schema: "clubmed",
                columns: table => new
                {
                    trp_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    trp_nom = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    trp_prix = table.Column<decimal>(type: "numeric(5,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_e_transport_trp", x => x.trp_id);
                    table.CheckConstraint("ck_trp_prix", "trp_prix > 0");
                });

            migrationBuilder.CreateTable(
                name: "t_e_typeactivite_tac",
                columns: table => new
                {
                    tac_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    tac_nom = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    tac_description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_e_typeactivite_tac", x => x.tac_id);
                });

            migrationBuilder.CreateTable(
                name: "t_e_typeclub_tcl",
                schema: "clubmed",
                columns: table => new
                {
                    tcl_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    tcl_nom = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_e_typeclub_tcl", x => x.tcl_id);
                });

            migrationBuilder.CreateTable(
                name: "t_e_club_clb",
                schema: "clubmed",
                columns: table => new
                {
                    clb_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    clb_iddomaineskiable = table.Column<int>(type: "integer", nullable: true),
                    clb_nom = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    clb_description = table.Column<string>(type: "text", nullable: true),
                    clb_lienpdf = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    clb_longitude = table.Column<decimal>(type: "numeric(14,11)", nullable: false),
                    clb_latitude = table.Column<decimal>(type: "numeric(14,11)", nullable: false),
                    clb_email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_e_club_clb", x => x.clb_id);
                    table.ForeignKey(
                        name: "fk_clb_dsk",
                        column: x => x.clb_iddomaineskiable,
                        principalSchema: "clubmed",
                        principalTable: "t_e_domaineskiable_dsk",
                        principalColumn: "dsk_id");
                });

            migrationBuilder.CreateTable(
                name: "t_e_ville_vil",
                schema: "clubmed",
                columns: table => new
                {
                    vil_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    vil_nom = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    vil_idpays = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_e_ville_vil", x => x.vil_id);
                    table.ForeignKey(
                        name: "fk_pay_vil",
                        column: x => x.vil_idpays,
                        principalSchema: "clubmed",
                        principalTable: "t_e_pays_pay",
                        principalColumn: "pay_id");
                });

            migrationBuilder.CreateTable(
                name: "t_j_payslocalisation_pal",
                schema: "clubmed",
                columns: table => new
                {
                    pal_idpays = table.Column<int>(type: "integer", nullable: false),
                    pal_idlocalisation = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_j_payslocalisation_pal", x => new { x.pal_idpays, x.pal_idlocalisation });
                    table.ForeignKey(
                        name: "fk_loc_pal",
                        column: x => x.pal_idlocalisation,
                        principalSchema: "clubmed",
                        principalTable: "t_e_localisation_loc",
                        principalColumn: "loc_id");
                    table.ForeignKey(
                        name: "fk_pay_pal",
                        column: x => x.pal_idpays,
                        principalSchema: "clubmed",
                        principalTable: "t_e_pays_pay",
                        principalColumn: "pay_id");
                });

            migrationBuilder.CreateTable(
                name: "t_e_activite_act",
                schema: "clubmed",
                columns: table => new
                {
                    act_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    act_idtypeactivite = table.Column<int>(type: "integer", nullable: false),
                    act_nom = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    act_description = table.Column<string>(type: "text", nullable: true),
                    act_agemin = table.Column<int>(type: "integer", nullable: true),
                    act_duree = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    act_prix = table.Column<decimal>(type: "numeric(7,2)", nullable: true),
                    act_estincluse = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_e_activite_act", x => x.act_id);
                    table.CheckConstraint("ck_act_agemin", "act_agemin > 0");
                    table.CheckConstraint("ck_act_prix", "act_prix > 0");
                    table.ForeignKey(
                        name: "fk_act_tac",
                        column: x => x.act_idtypeactivite,
                        principalTable: "t_e_typeactivite_tac",
                        principalColumn: "tac_id");
                });

            migrationBuilder.CreateTable(
                name: "t_e_bar_bar",
                schema: "clubmed",
                columns: table => new
                {
                    res_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    res_idclub = table.Column<int>(type: "integer", nullable: false),
                    res_nom = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    res_description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_e_bar_bar", x => x.res_id);
                    table.ForeignKey(
                        name: "fk_clb_bar",
                        column: x => x.res_idclub,
                        principalSchema: "clubmed",
                        principalTable: "t_e_club_clb",
                        principalColumn: "clb_id");
                });

            migrationBuilder.CreateTable(
                name: "t_e_restaurant_ret",
                columns: table => new
                {
                    res_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    res_idclub = table.Column<int>(type: "integer", nullable: false),
                    res_nom = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    res_description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_e_restaurant_ret", x => x.res_id);
                    table.ForeignKey(
                        name: "fk_clb_ret",
                        column: x => x.res_idclub,
                        principalSchema: "clubmed",
                        principalTable: "t_e_club_clb",
                        principalColumn: "clb_id");
                });

            migrationBuilder.CreateTable(
                name: "t_j_clubcaracteristique_cct",
                schema: "clubmed",
                columns: table => new
                {
                    cct_idclub = table.Column<int>(type: "integer", nullable: false),
                    cct_idcaracteristique = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_j_clubcaracteristique_cct", x => new { x.cct_idclub, x.cct_idcaracteristique });
                    table.ForeignKey(
                        name: "fk_clb_cct",
                        column: x => x.cct_idclub,
                        principalSchema: "clubmed",
                        principalTable: "t_e_club_clb",
                        principalColumn: "clb_id");
                    table.ForeignKey(
                        name: "fk_ctq_cct",
                        column: x => x.cct_idcaracteristique,
                        principalSchema: "clubmed",
                        principalTable: "t_e_caracteristique_ctq",
                        principalColumn: "ctq_id");
                });

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

            migrationBuilder.CreateTable(
                name: "t_j_clubpayslocalisation_cps",
                schema: "clubmed",
                columns: table => new
                {
                    cps_idclub = table.Column<int>(type: "integer", nullable: false),
                    cps_idpays = table.Column<int>(type: "integer", nullable: false),
                    cps_idlocalisation = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_j_clubpayslocalisation_cps", x => new { x.cps_idclub, x.cps_idpays, x.cps_idlocalisation });
                    table.ForeignKey(
                        name: "fk_clb_cps",
                        column: x => x.cps_idclub,
                        principalSchema: "clubmed",
                        principalTable: "t_e_club_clb",
                        principalColumn: "clb_id");
                    table.ForeignKey(
                        name: "fk_loc_cps",
                        column: x => x.cps_idlocalisation,
                        principalSchema: "clubmed",
                        principalTable: "t_e_localisation_loc",
                        principalColumn: "loc_id");
                    table.ForeignKey(
                        name: "fk_pay_cps",
                        column: x => x.cps_idpays,
                        principalSchema: "clubmed",
                        principalTable: "t_e_pays_pay",
                        principalColumn: "pay_id");
                });

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

            migrationBuilder.CreateTable(
                name: "t_j_villecodepostal_vcp",
                schema: "clubmed",
                columns: table => new
                {
                    rmt_idrestaurant = table.Column<int>(type: "integer", nullable: false),
                    rmt_idmultimedia = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_j_villecodepostal_vcp", x => new { x.rmt_idrestaurant, x.rmt_idmultimedia });
                    table.ForeignKey(
                        name: "fk_cpl_vcp",
                        column: x => x.rmt_idmultimedia,
                        principalSchema: "clubmed",
                        principalTable: "t_e_codepostal_cpl",
                        principalColumn: "cpl_id");
                    table.ForeignKey(
                        name: "fk_vil_vcp",
                        column: x => x.rmt_idrestaurant,
                        principalSchema: "clubmed",
                        principalTable: "t_e_ville_vil",
                        principalColumn: "vil_id");
                });

            migrationBuilder.CreateTable(
                name: "t_e_activiteenfant_ace",
                schema: "clubmed",
                columns: table => new
                {
                    act_id = table.Column<int>(type: "integer", nullable: false),
                    ace_agemax = table.Column<decimal>(type: "numeric(4,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_e_activiteenfant_ace", x => x.act_id);
                    table.ForeignKey(
                        name: "FK_t_e_activiteenfant_ace_t_e_activite_act_act_id",
                        column: x => x.act_id,
                        principalSchema: "clubmed",
                        principalTable: "t_e_activite_act",
                        principalColumn: "act_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "t_j_clubactivite_cac",
                schema: "clubmed",
                columns: table => new
                {
                    cac_idclub = table.Column<int>(type: "integer", nullable: false),
                    cac_idactivite = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_j_clubactivite_cac", x => new { x.cac_idclub, x.cac_idactivite });
                    table.ForeignKey(
                        name: "fk_act_cac",
                        column: x => x.cac_idactivite,
                        principalSchema: "clubmed",
                        principalTable: "t_e_activite_act",
                        principalColumn: "act_id");
                    table.ForeignKey(
                        name: "fk_clb_cac",
                        column: x => x.cac_idclub,
                        principalSchema: "clubmed",
                        principalTable: "t_e_club_clb",
                        principalColumn: "clb_id");
                });

            migrationBuilder.CreateTable(
                name: "t_j_barmultimedia_bmt",
                schema: "clubmed",
                columns: table => new
                {
                    bmt_idbar = table.Column<int>(type: "integer", nullable: false),
                    bmt_idmultimedia = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_j_barmultimedia_bmt", x => new { x.bmt_idbar, x.bmt_idmultimedia });
                    table.ForeignKey(
                        name: "fk_bar_bmt",
                        column: x => x.bmt_idbar,
                        principalSchema: "clubmed",
                        principalTable: "t_e_bar_bar",
                        principalColumn: "res_id");
                    table.ForeignKey(
                        name: "fk_mlm_bmt",
                        column: x => x.bmt_idmultimedia,
                        principalSchema: "clubmed",
                        principalTable: "t_e_multimedia_mtm",
                        principalColumn: "mtm_id");
                });

            migrationBuilder.CreateTable(
                name: "t_j_restaurantmultimedia_rmt",
                schema: "clubmed",
                columns: table => new
                {
                    rmt_idrestaurant = table.Column<int>(type: "integer", nullable: false),
                    rmt_idmultimedia = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_j_restaurantmultimedia_rmt", x => new { x.rmt_idrestaurant, x.rmt_idmultimedia });
                    table.ForeignKey(
                        name: "fk_mlm_rmt",
                        column: x => x.rmt_idmultimedia,
                        principalSchema: "clubmed",
                        principalTable: "t_e_multimedia_mtm",
                        principalColumn: "mtm_id");
                    table.ForeignKey(
                        name: "fk_ret_rmt",
                        column: x => x.rmt_idrestaurant,
                        principalTable: "t_e_restaurant_ret",
                        principalColumn: "res_id");
                });

            migrationBuilder.CreateTable(
                name: "t_j_clubactiviteenfant_cae",
                schema: "clubmed",
                columns: table => new
                {
                    cae_idclub = table.Column<int>(type: "integer", nullable: false),
                    cae_idactiviteenfant = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_j_clubactiviteenfant_cae", x => new { x.cae_idclub, x.cae_idactiviteenfant });
                    table.ForeignKey(
                        name: "fk_ace_cae",
                        column: x => x.cae_idactiviteenfant,
                        principalSchema: "clubmed",
                        principalTable: "t_e_activiteenfant_ace",
                        principalColumn: "act_id");
                    table.ForeignKey(
                        name: "fk_clb_cae",
                        column: x => x.cae_idclub,
                        principalSchema: "clubmed",
                        principalTable: "t_e_club_clb",
                        principalColumn: "clb_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_t_e_activite_act_act_idtypeactivite",
                schema: "clubmed",
                table: "t_e_activite_act",
                column: "act_idtypeactivite");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_bar_bar_res_idclub",
                schema: "clubmed",
                table: "t_e_bar_bar",
                column: "res_idclub");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_club_clb_clb_email",
                schema: "clubmed",
                table: "t_e_club_clb",
                column: "clb_email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_t_e_club_clb_clb_iddomaineskiable",
                schema: "clubmed",
                table: "t_e_club_clb",
                column: "clb_iddomaineskiable");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_restaurant_ret_res_idclub",
                table: "t_e_restaurant_ret",
                column: "res_idclub");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_ville_vil_vil_idpays",
                schema: "clubmed",
                table: "t_e_ville_vil",
                column: "vil_idpays");

            migrationBuilder.CreateIndex(
                name: "IX_t_j_barmultimedia_bmt_bmt_idmultimedia",
                schema: "clubmed",
                table: "t_j_barmultimedia_bmt",
                column: "bmt_idmultimedia");

            migrationBuilder.CreateIndex(
                name: "IX_t_j_clubactivite_cac_cac_idactivite",
                schema: "clubmed",
                table: "t_j_clubactivite_cac",
                column: "cac_idactivite");

            migrationBuilder.CreateIndex(
                name: "IX_t_j_clubactiviteenfant_cae_cae_idactiviteenfant",
                schema: "clubmed",
                table: "t_j_clubactiviteenfant_cae",
                column: "cae_idactiviteenfant");

            migrationBuilder.CreateIndex(
                name: "IX_t_j_clubcaracteristique_cct_cct_idcaracteristique",
                schema: "clubmed",
                table: "t_j_clubcaracteristique_cct",
                column: "cct_idcaracteristique");

            migrationBuilder.CreateIndex(
                name: "IX_t_j_clubmultimedia_cmt_cmt_idmultimedia",
                schema: "clubmed",
                table: "t_j_clubmultimedia_cmt",
                column: "cmt_idmultimedia");

            migrationBuilder.CreateIndex(
                name: "IX_t_j_clubpayslocalisation_cps_cps_idlocalisation",
                schema: "clubmed",
                table: "t_j_clubpayslocalisation_cps",
                column: "cps_idlocalisation");

            migrationBuilder.CreateIndex(
                name: "IX_t_j_clubpayslocalisation_cps_cps_idpays",
                schema: "clubmed",
                table: "t_j_clubpayslocalisation_cps",
                column: "cps_idpays");

            migrationBuilder.CreateIndex(
                name: "IX_t_j_clubtransport_ctr_ctr_idtransport",
                schema: "clubmed",
                table: "t_j_clubtransport_ctr",
                column: "ctr_idtransport");

            migrationBuilder.CreateIndex(
                name: "IX_t_j_payslocalisation_pal_pal_idlocalisation",
                schema: "clubmed",
                table: "t_j_payslocalisation_pal",
                column: "pal_idlocalisation");

            migrationBuilder.CreateIndex(
                name: "IX_t_j_restaurantmultimedia_rmt_rmt_idmultimedia",
                schema: "clubmed",
                table: "t_j_restaurantmultimedia_rmt",
                column: "rmt_idmultimedia");

            migrationBuilder.CreateIndex(
                name: "IX_t_j_villecodepostal_vcp_rmt_idmultimedia",
                schema: "clubmed",
                table: "t_j_villecodepostal_vcp",
                column: "rmt_idmultimedia");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "t_e_cookie_cok",
                schema: "clubmed");

            migrationBuilder.DropTable(
                name: "t_e_typeclub_tcl",
                schema: "clubmed");

            migrationBuilder.DropTable(
                name: "t_j_barmultimedia_bmt",
                schema: "clubmed");

            migrationBuilder.DropTable(
                name: "t_j_clubactivite_cac",
                schema: "clubmed");

            migrationBuilder.DropTable(
                name: "t_j_clubactiviteenfant_cae",
                schema: "clubmed");

            migrationBuilder.DropTable(
                name: "t_j_clubcaracteristique_cct",
                schema: "clubmed");

            migrationBuilder.DropTable(
                name: "t_j_clubmultimedia_cmt",
                schema: "clubmed");

            migrationBuilder.DropTable(
                name: "t_j_clubpayslocalisation_cps",
                schema: "clubmed");

            migrationBuilder.DropTable(
                name: "t_j_clubtransport_ctr",
                schema: "clubmed");

            migrationBuilder.DropTable(
                name: "t_j_payslocalisation_pal",
                schema: "clubmed");

            migrationBuilder.DropTable(
                name: "t_j_restaurantmultimedia_rmt",
                schema: "clubmed");

            migrationBuilder.DropTable(
                name: "t_j_villecodepostal_vcp",
                schema: "clubmed");

            migrationBuilder.DropTable(
                name: "t_e_bar_bar",
                schema: "clubmed");

            migrationBuilder.DropTable(
                name: "t_e_activiteenfant_ace",
                schema: "clubmed");

            migrationBuilder.DropTable(
                name: "t_e_caracteristique_ctq",
                schema: "clubmed");

            migrationBuilder.DropTable(
                name: "t_e_transport_trp",
                schema: "clubmed");

            migrationBuilder.DropTable(
                name: "t_e_localisation_loc",
                schema: "clubmed");

            migrationBuilder.DropTable(
                name: "t_e_multimedia_mtm",
                schema: "clubmed");

            migrationBuilder.DropTable(
                name: "t_e_restaurant_ret");

            migrationBuilder.DropTable(
                name: "t_e_codepostal_cpl",
                schema: "clubmed");

            migrationBuilder.DropTable(
                name: "t_e_ville_vil",
                schema: "clubmed");

            migrationBuilder.DropTable(
                name: "t_e_activite_act",
                schema: "clubmed");

            migrationBuilder.DropTable(
                name: "t_e_club_clb",
                schema: "clubmed");

            migrationBuilder.DropTable(
                name: "t_e_pays_pay",
                schema: "clubmed");

            migrationBuilder.DropTable(
                name: "t_e_typeactivite_tac");

            migrationBuilder.DropTable(
                name: "t_e_domaineskiable_dsk",
                schema: "clubmed");
        }
    }
}
