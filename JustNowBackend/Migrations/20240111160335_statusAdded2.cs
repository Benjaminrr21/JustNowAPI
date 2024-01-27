using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JustNowBackend.Migrations
{
    public partial class statusAdded2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Requests",
                newName: "Statuss");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Statuss",
                table: "Requests",
                newName: "Status");
        }
    }
}
