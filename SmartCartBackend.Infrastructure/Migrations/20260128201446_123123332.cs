using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartCartBackend.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _123123332 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "Units",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "Tags",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "MealTypes",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "Ingredients",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "IngredientCategories",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "FoodRation",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "Dishes",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "DishCategories",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "Difficulty",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "DietStrategies",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "CookingTime",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "Allergies",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "ActivityLevels",
                type: "integer",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "ActivityLevels",
                keyColumn: "Id",
                keyValue: 1,
                column: "Order",
                value: null);

            migrationBuilder.UpdateData(
                table: "ActivityLevels",
                keyColumn: "Id",
                keyValue: 2,
                column: "Order",
                value: null);

            migrationBuilder.UpdateData(
                table: "ActivityLevels",
                keyColumn: "Id",
                keyValue: 3,
                column: "Order",
                value: null);

            migrationBuilder.UpdateData(
                table: "ActivityLevels",
                keyColumn: "Id",
                keyValue: 4,
                column: "Order",
                value: null);

            migrationBuilder.UpdateData(
                table: "ActivityLevels",
                keyColumn: "Id",
                keyValue: 5,
                column: "Order",
                value: null);

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 1,
                column: "Order",
                value: null);

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 2,
                column: "Order",
                value: null);

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 3,
                column: "Order",
                value: null);

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 4,
                column: "Order",
                value: null);

            migrationBuilder.UpdateData(
                table: "CookingTime",
                keyColumn: "Id",
                keyValue: 1,
                column: "Order",
                value: null);

            migrationBuilder.UpdateData(
                table: "CookingTime",
                keyColumn: "Id",
                keyValue: 2,
                column: "Order",
                value: null);

            migrationBuilder.UpdateData(
                table: "CookingTime",
                keyColumn: "Id",
                keyValue: 3,
                column: "Order",
                value: null);

            migrationBuilder.UpdateData(
                table: "CookingTime",
                keyColumn: "Id",
                keyValue: 4,
                column: "Order",
                value: null);

            migrationBuilder.UpdateData(
                table: "DietStrategies",
                keyColumn: "Id",
                keyValue: 1,
                column: "Order",
                value: null);

            migrationBuilder.UpdateData(
                table: "DietStrategies",
                keyColumn: "Id",
                keyValue: 2,
                column: "Order",
                value: null);

            migrationBuilder.UpdateData(
                table: "DietStrategies",
                keyColumn: "Id",
                keyValue: 3,
                column: "Order",
                value: null);

            migrationBuilder.UpdateData(
                table: "DietStrategies",
                keyColumn: "Id",
                keyValue: 4,
                column: "Order",
                value: null);

            migrationBuilder.UpdateData(
                table: "Difficulty",
                keyColumn: "Id",
                keyValue: 1,
                column: "Order",
                value: null);

            migrationBuilder.UpdateData(
                table: "Difficulty",
                keyColumn: "Id",
                keyValue: 2,
                column: "Order",
                value: null);

            migrationBuilder.UpdateData(
                table: "Difficulty",
                keyColumn: "Id",
                keyValue: 3,
                column: "Order",
                value: null);

            migrationBuilder.UpdateData(
                table: "FoodRation",
                keyColumn: "Id",
                keyValue: 1,
                column: "Order",
                value: null);

            migrationBuilder.UpdateData(
                table: "FoodRation",
                keyColumn: "Id",
                keyValue: 2,
                column: "Order",
                value: null);

            migrationBuilder.UpdateData(
                table: "FoodRation",
                keyColumn: "Id",
                keyValue: 3,
                column: "Order",
                value: null);

            migrationBuilder.UpdateData(
                table: "FoodRation",
                keyColumn: "Id",
                keyValue: 4,
                column: "Order",
                value: null);

            migrationBuilder.UpdateData(
                table: "MealTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Order",
                value: null);

            migrationBuilder.UpdateData(
                table: "MealTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "Order",
                value: null);

            migrationBuilder.UpdateData(
                table: "MealTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "Order",
                value: null);

            migrationBuilder.UpdateData(
                table: "MealTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "Order",
                value: null);

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 1,
                column: "Order",
                value: null);

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 2,
                column: "Order",
                value: null);

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 3,
                column: "Order",
                value: null);

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 4,
                column: "Order",
                value: null);

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 5,
                column: "Order",
                value: null);

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 6,
                column: "Order",
                value: null);

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 7,
                column: "Order",
                value: null);

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 8,
                column: "Order",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_NutritionPlanChoices_Group",
                table: "NutritionPlanChoices",
                column: "Group");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_NutritionPlanChoices_Group",
                table: "NutritionPlanChoices");

            migrationBuilder.DropColumn(
                name: "Order",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "Order",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "Order",
                table: "MealTypes");

            migrationBuilder.DropColumn(
                name: "Order",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "Order",
                table: "IngredientCategories");

            migrationBuilder.DropColumn(
                name: "Order",
                table: "FoodRation");

            migrationBuilder.DropColumn(
                name: "Order",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "Order",
                table: "DishCategories");

            migrationBuilder.DropColumn(
                name: "Order",
                table: "Difficulty");

            migrationBuilder.DropColumn(
                name: "Order",
                table: "DietStrategies");

            migrationBuilder.DropColumn(
                name: "Order",
                table: "CookingTime");

            migrationBuilder.DropColumn(
                name: "Order",
                table: "Allergies");

            migrationBuilder.DropColumn(
                name: "Order",
                table: "ActivityLevels");
        }
    }
}
