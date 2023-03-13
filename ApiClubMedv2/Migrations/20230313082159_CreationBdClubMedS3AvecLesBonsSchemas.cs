using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiClubMedv2.Migrations
{
    public partial class CreationBdClubMedS3AvecLesBonsSchemas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "t_e_typeactivite_tac",
                newName: "t_e_typeactivite_tac",
                newSchema: "clubmed");

            migrationBuilder.RenameTable(
                name: "t_e_restaurant_ret",
                newName: "t_e_restaurant_ret",
                newSchema: "clubmed");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "t_e_typeactivite_tac",
                schema: "clubmed",
                newName: "t_e_typeactivite_tac");

            migrationBuilder.RenameTable(
                name: "t_e_restaurant_ret",
                schema: "clubmed",
                newName: "t_e_restaurant_ret");
        }
    }
}
