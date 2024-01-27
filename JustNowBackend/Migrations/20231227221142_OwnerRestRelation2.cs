using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JustNowBackend.Migrations
{
    public partial class OwnerRestRelation2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RestaurantId",
                table: "Owners");

            migrationBuilder.AddColumn<int>(
                name: "OwnerRestaurantId",
                table: "Restaurants",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_OwnerRestaurantId",
                table: "Restaurants",
                column: "OwnerRestaurantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurants_Owners_OwnerRestaurantId",
                table: "Restaurants",
                column: "OwnerRestaurantId",
                principalTable: "Owners",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Restaurants_Owners_OwnerRestaurantId",
                table: "Restaurants");

            migrationBuilder.DropIndex(
                name: "IX_Restaurants_OwnerRestaurantId",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "OwnerRestaurantId",
                table: "Restaurants");

            migrationBuilder.AddColumn<int>(
                name: "RestaurantId",
                table: "Owners",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
