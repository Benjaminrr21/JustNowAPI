using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JustNowBackend.Migrations
{
    public partial class gradesadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRestaurantGrades_Restaurants_RestaurantId",
                table: "UserRestaurantGrades");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRestaurantGrades_Users_UserId",
                table: "UserRestaurantGrades");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRestaurantGrades",
                table: "UserRestaurantGrades");

            migrationBuilder.RenameTable(
                name: "UserRestaurantGrades",
                newName: "Grades");

            migrationBuilder.RenameIndex(
                name: "IX_UserRestaurantGrades_UserId",
                table: "Grades",
                newName: "IX_Grades_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Grades",
                table: "Grades",
                columns: new[] { "RestaurantId", "UserId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_Restaurants_RestaurantId",
                table: "Grades",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_Users_UserId",
                table: "Grades",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Grades_Restaurants_RestaurantId",
                table: "Grades");

            migrationBuilder.DropForeignKey(
                name: "FK_Grades_Users_UserId",
                table: "Grades");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Grades",
                table: "Grades");

            migrationBuilder.RenameTable(
                name: "Grades",
                newName: "UserRestaurantGrades");

            migrationBuilder.RenameIndex(
                name: "IX_Grades_UserId",
                table: "UserRestaurantGrades",
                newName: "IX_UserRestaurantGrades_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRestaurantGrades",
                table: "UserRestaurantGrades",
                columns: new[] { "RestaurantId", "UserId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserRestaurantGrades_Restaurants_RestaurantId",
                table: "UserRestaurantGrades",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRestaurantGrades_Users_UserId",
                table: "UserRestaurantGrades",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
