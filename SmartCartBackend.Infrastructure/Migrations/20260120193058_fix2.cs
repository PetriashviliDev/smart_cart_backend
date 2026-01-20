using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartCartBackend.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class fix2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Allergies_Ingredients_IngredientId",
                table: "Allergies");

            migrationBuilder.DropForeignKey(
                name: "FK_DishEmbeddings_Dishes_DishId",
                table: "DishEmbeddings");

            migrationBuilder.DropForeignKey(
                name: "FK_DishEmbeddings_Dishes_DishId1",
                table: "DishEmbeddings");

            migrationBuilder.DropIndex(
                name: "IX_DishEmbeddings_DishId1",
                table: "DishEmbeddings");

            migrationBuilder.DropIndex(
                name: "IX_Allergies_IngredientId",
                table: "Allergies");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "DishId1",
                table: "DishEmbeddings");

            migrationBuilder.DropColumn(
                name: "IngredientId",
                table: "Allergies");

            migrationBuilder.AddForeignKey(
                name: "FK_DishEmbeddings_Dishes_DishId",
                table: "DishEmbeddings",
                column: "DishId",
                principalTable: "Dishes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DishEmbeddings_Dishes_DishId",
                table: "DishEmbeddings");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Ingredients",
                type: "numeric(10,2)",
                precision: 10,
                scale: 2,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Dishes",
                type: "numeric(10,2)",
                precision: 10,
                scale: 2,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DishId1",
                table: "DishEmbeddings",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IngredientId",
                table: "Allergies",
                type: "integer",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 1,
                column: "IngredientId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 2,
                column: "IngredientId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 3,
                column: "IngredientId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 4,
                column: "IngredientId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_DishEmbeddings_DishId1",
                table: "DishEmbeddings",
                column: "DishId1",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Allergies_IngredientId",
                table: "Allergies",
                column: "IngredientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Allergies_Ingredients_IngredientId",
                table: "Allergies",
                column: "IngredientId",
                principalTable: "Ingredients",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DishEmbeddings_Dishes_DishId",
                table: "DishEmbeddings",
                column: "DishId",
                principalTable: "Dishes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DishEmbeddings_Dishes_DishId1",
                table: "DishEmbeddings",
                column: "DishId1",
                principalTable: "Dishes",
                principalColumn: "Id");
        }
    }
}
