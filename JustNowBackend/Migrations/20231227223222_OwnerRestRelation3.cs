using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JustNowBackend.Migrations
{
    public partial class OwnerRestRelation3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Restaurants_Owners_OwnerRestaurantId",
                table: "Restaurants");

            migrationBuilder.RenameColumn(
                name: "OwnerRestaurantId",
                table: "Restaurants",
                newName: "ownerRestaurantId");

            migrationBuilder.RenameIndex(
                name: "IX_Restaurants_OwnerRestaurantId",
                table: "Restaurants",
                newName: "IX_Restaurants_ownerRestaurantId");

            migrationBuilder.AlterColumn<int>(
                name: "ownerRestaurantId",
                table: "Restaurants",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurants_Owners_ownerRestaurantId",
                table: "Restaurants",
                column: "ownerRestaurantId",
                principalTable: "Owners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Restaurants_Owners_ownerRestaurantId",
                table: "Restaurants");

            migrationBuilder.RenameColumn(
                name: "ownerRestaurantId",
                table: "Restaurants",
                newName: "OwnerRestaurantId");

            migrationBuilder.RenameIndex(
                name: "IX_Restaurants_ownerRestaurantId",
                table: "Restaurants",
                newName: "IX_Restaurants_OwnerRestaurantId");

            migrationBuilder.AlterColumn<int>(
                name: "OwnerRestaurantId",
                table: "Restaurants",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurants_Owners_OwnerRestaurantId",
                table: "Restaurants",
                column: "OwnerRestaurantId",
                principalTable: "Owners",
                principalColumn: "Id");
        }
    }
}
