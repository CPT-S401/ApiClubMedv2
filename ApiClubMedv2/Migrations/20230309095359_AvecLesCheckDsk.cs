using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiClubMedv2.Migrations
{
    public partial class AvecLesCheckDsk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddCheckConstraint(
                name: "ck_dsk_altbasse_althaute",
                schema: "clubmed",
                table: "t_e_domaineskiable_dsk",
                sql: "dsk_altitudebasse > 0 and dsk_altitudehaute > dsk_altitudebasse");

            migrationBuilder.AddCheckConstraint(
                name: "ck_dsk_longueurpistes",
                schema: "clubmed",
                table: "t_e_domaineskiable_dsk",
                sql: "dsk_longueurpistes > 0");

            migrationBuilder.AddCheckConstraint(
                name: "ck_dsk_nombrepistes",
                schema: "clubmed",
                table: "t_e_domaineskiable_dsk",
                sql: "dsk_nbpistes > 0");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "ck_dsk_altbasse_althaute",
                schema: "clubmed",
                table: "t_e_domaineskiable_dsk");

            migrationBuilder.DropCheckConstraint(
                name: "ck_dsk_longueurpistes",
                schema: "clubmed",
                table: "t_e_domaineskiable_dsk");

            migrationBuilder.DropCheckConstraint(
                name: "ck_dsk_nombrepistes",
                schema: "clubmed",
                table: "t_e_domaineskiable_dsk");
        }
    }
}
