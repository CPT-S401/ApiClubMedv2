using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ApiClubMedv2.Migrations
{
    public partial class CreationBDFilmRatings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "t_e_club_clb",
                columns: table => new
                {
                    clb_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    clb_iddomaineskiable = table.Column<int>(type: "integer", nullable: false),
                    clb_nom = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    clb_description = table.Column<string>(type: "text", nullable: false),
                    clb_longitude = table.Column<decimal>(type: "numeric(14,11)", nullable: false),
                    clb_latitude = table.Column<decimal>(type: "numeric(14,11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_e_club_clb", x => x.clb_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "t_e_club_clb");
        }
    }
}
