using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JustNowBackend.Migrations
{
    public partial class statusrestadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Restaurants",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Restaurants");
        }
    }
}
