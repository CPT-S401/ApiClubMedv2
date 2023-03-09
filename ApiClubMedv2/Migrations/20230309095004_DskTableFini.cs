using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiClubMedv2.Migrations
{
    public partial class DskTableFini : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "dsk_altitudebasse",
                schema: "clubmed",
                table: "t_e_domaineskiable_dsk",
                type: "numeric(6,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "dsk_altitudehaute",
                schema: "clubmed",
                table: "t_e_domaineskiable_dsk",
                type: "numeric(6,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "dsk_infoski",
                schema: "clubmed",
                table: "t_e_domaineskiable_dsk",
                type: "varchar(200)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "dsk_longueurpistes",
                schema: "clubmed",
                table: "t_e_domaineskiable_dsk",
                type: "numeric(3,0)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "dsk_nbpistes",
                schema: "clubmed",
                table: "t_e_domaineskiable_dsk",
                type: "numeric(3,0)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<string>(
                name: "clb_lienpdf",
                schema: "clubmed",
                table: "t_e_club_clb",
                type: "varchar(200)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "dsk_altitudebasse",
                schema: "clubmed",
                table: "t_e_domaineskiable_dsk");

            migrationBuilder.DropColumn(
                name: "dsk_altitudehaute",
                schema: "clubmed",
                table: "t_e_domaineskiable_dsk");

            migrationBuilder.DropColumn(
                name: "dsk_infoski",
                schema: "clubmed",
                table: "t_e_domaineskiable_dsk");

            migrationBuilder.DropColumn(
                name: "dsk_longueurpistes",
                schema: "clubmed",
                table: "t_e_domaineskiable_dsk");

            migrationBuilder.DropColumn(
                name: "dsk_nbpistes",
                schema: "clubmed",
                table: "t_e_domaineskiable_dsk");

            migrationBuilder.AlterColumn<string>(
                name: "clb_lienpdf",
                schema: "clubmed",
                table: "t_e_club_clb",
                type: "varchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldMaxLength: 100,
                oldNullable: true);
        }
    }
}
