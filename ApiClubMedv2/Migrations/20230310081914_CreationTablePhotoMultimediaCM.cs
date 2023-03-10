using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ApiClubMedv2.Migrations
{
    public partial class CreationTablePhotoMultimediaCM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "t_e_multimedia_mtm",
                columns: table => new
                {
                    mtm_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    mtm_nom = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    mtm_description = table.Column<string>(type: "text", nullable: true),
                    mtm_lien = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    mtm_idclub = table.Column<int>(type: "integer", nullable: true),
                    mtm_idrestauration = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_e_multimedia_mtm", x => x.mtm_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "t_e_multimedia_mtm");
        }
    }
}
