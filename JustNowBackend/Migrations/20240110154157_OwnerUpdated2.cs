using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JustNowBackend.Migrations
{
    public partial class OwnerUpdated2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OwnerRestaurantId",
                table: "UserRoles",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_OwnerRestaurantId",
                table: "UserRoles",
                column: "OwnerRestaurantId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_Owners_OwnerRestaurantId",
                table: "UserRoles",
                column: "OwnerRestaurantId",
                principalTable: "Owners",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Owners_OwnerRestaurantId",
                table: "UserRoles");

            migrationBuilder.DropIndex(
                name: "IX_UserRoles_OwnerRestaurantId",
                table: "UserRoles");

            migrationBuilder.DropColumn(
                name: "OwnerRestaurantId",
                table: "UserRoles");
        }
    }
}
