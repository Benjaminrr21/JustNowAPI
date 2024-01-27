using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JustNowBackend.Migrations
{
    public partial class mm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Restaurants_Owners_ownerRestaurantId",
                table: "Restaurants");

            migrationBuilder.DropIndex(
                name: "IX_Restaurants_ownerRestaurantId",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "ownerRestaurantId",
                table: "Restaurants");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_OwnerId",
                table: "Restaurants",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurants_Owners_OwnerId",
                table: "Restaurants",
                column: "OwnerId",
                principalTable: "Owners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Restaurants_Owners_OwnerId",
                table: "Restaurants");

            migrationBuilder.DropIndex(
                name: "IX_Restaurants_OwnerId",
                table: "Restaurants");

            migrationBuilder.AddColumn<int>(
                name: "ownerRestaurantId",
                table: "Restaurants",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_ownerRestaurantId",
                table: "Restaurants",
                column: "ownerRestaurantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurants_Owners_ownerRestaurantId",
                table: "Restaurants",
                column: "ownerRestaurantId",
                principalTable: "Owners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
