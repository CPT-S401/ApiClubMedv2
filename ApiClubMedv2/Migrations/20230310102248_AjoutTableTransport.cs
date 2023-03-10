using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ApiClubMedv2.Migrations
{
    public partial class AjoutTableTransport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "t_e_transport_trp",
                schema: "clubmed");
        }
    }
}
