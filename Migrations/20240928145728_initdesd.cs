using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace running_apps.Migrations
{
    public partial class initdesd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "clubCategory",
                table: "Clubs",
                newName: "ClubCategory");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ClubCategory",
                table: "Clubs",
                newName: "clubCategory");
        }
    }
}
