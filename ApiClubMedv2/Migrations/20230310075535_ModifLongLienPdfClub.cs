using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiClubMedv2.Migrations
{
    public partial class ModifLongLienPdfClub : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "clb_lienpdf",
                schema: "clubmed",
                table: "t_e_club_clb",
                type: "varchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldMaxLength: 200,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "clb_lienpdf",
                schema: "clubmed",
                table: "t_e_club_clb",
                type: "varchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldMaxLength: 255,
                oldNullable: true);
        }
    }
}
