using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiClubMedv2.Migrations
{
    public partial class AvecLesNullDskV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "dsk_nbpistes",
                schema: "clubmed",
                table: "t_e_domaineskiable_dsk",
                type: "numeric(3,0)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric(3,0)");

            migrationBuilder.AlterColumn<decimal>(
                name: "dsk_longueurpistes",
                schema: "clubmed",
                table: "t_e_domaineskiable_dsk",
                type: "numeric(3,0)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric(3,0)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "dsk_nbpistes",
                schema: "clubmed",
                table: "t_e_domaineskiable_dsk",
                type: "numeric(3,0)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "numeric(3,0)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "dsk_longueurpistes",
                schema: "clubmed",
                table: "t_e_domaineskiable_dsk",
                type: "numeric(3,0)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "numeric(3,0)",
                oldNullable: true);
        }
    }
}
