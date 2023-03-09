using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ApiClubMedv2.Migrations
{
    public partial class BruhJeRefaisLaBDClubMedS3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "clubmed");

            migrationBuilder.CreateTable(
                name: "t_e_domaineskiable_dsk",
                schema: "clubmed",
                columns: table => new
                {
                    dsk_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    dsk_nom = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    dsk_description = table.Column<string>(type: "text", nullable: true),
                    dsk_nomstation = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_e_domaineskiable_dsk", x => x.dsk_id);
                });

            migrationBuilder.CreateTable(
                name: "t_e_club_clb",
                schema: "clubmed",
                columns: table => new
                {
                    clb_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    clb_iddomaineskiable = table.Column<int>(type: "integer", nullable: false),
                    clb_nom = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    clb_description = table.Column<string>(type: "text", nullable: true),
                    clb_lienpdf = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "t_e_club_clb",
                schema: "clubmed");

            migrationBuilder.DropTable(
                name: "t_e_domaineskiable_dsk",
                schema: "clubmed");
        }
    }
}
