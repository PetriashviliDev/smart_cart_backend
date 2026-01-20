using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SmartCartBackend.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class fix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAdded",
                table: "Units",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsAdded",
                table: "MealTypes",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsAdded",
                table: "Ingredients",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsAdded",
                table: "FoodRation",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsAdded",
                table: "Dishes",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsAdded",
                table: "DishCategories",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsAdded",
                table: "Difficulty",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsAdded",
                table: "DietStrategies",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "CookingTime",
                type: "character varying(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "CookingTime",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<string>(
                name: "InternalName",
                table: "CookingTime",
                type: "character varying(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "CookingTime",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<bool>(
                name: "IsAdded",
                table: "CookingTime",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Limit",
                table: "CookingTime",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsAdded",
                table: "Allergies",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsAdded",
                table: "ActivityLevels",
                type: "boolean",
                nullable: false,
                defaultValue: false);
            
            migrationBuilder.UpdateData(
                table: "CookingTime",
                keyColumn: "Id",
                keyValue: 1,
                column: "Limit",
                value: null);

            migrationBuilder.UpdateData(
                table: "CookingTime",
                keyColumn: "Id",
                keyValue: 2,
                column: "Limit",
                value: null);

            migrationBuilder.UpdateData(
                table: "CookingTime",
                keyColumn: "Id",
                keyValue: 3,
                column: "Limit",
                value: null);

            migrationBuilder.UpdateData(
                table: "CookingTime",
                keyColumn: "Id",
                keyValue: 4,
                column: "Limit",
                value: null);

            migrationBuilder.UpdateData(
                table: "FoodRation",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsAdded",
                value: false);

            migrationBuilder.UpdateData(
                table: "FoodRation",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsAdded",
                value: false);

            migrationBuilder.UpdateData(
                table: "FoodRation",
                keyColumn: "Id",
                keyValue: 3,
                column: "IsAdded",
                value: false);

            migrationBuilder.UpdateData(
                table: "FoodRation",
                keyColumn: "Id",
                keyValue: 4,
                column: "IsAdded",
                value: false);

            migrationBuilder.CreateIndex(
                name: "IX_CookingTime_InternalName",
                table: "CookingTime",
                column: "InternalName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CookingTime_InternalName",
                table: "CookingTime");

            migrationBuilder.DropColumn(
                name: "IsAdded",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "IsAdded",
                table: "MealTypes");

            migrationBuilder.DropColumn(
                name: "IsAdded",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "IsAdded",
                table: "FoodRation");

            migrationBuilder.DropColumn(
                name: "IsAdded",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "IsAdded",
                table: "DishCategories");

            migrationBuilder.DropColumn(
                name: "IsAdded",
                table: "Difficulty");

            migrationBuilder.DropColumn(
                name: "IsAdded",
                table: "DietStrategies");

            migrationBuilder.DropColumn(
                name: "IsAdded",
                table: "CookingTime");

            migrationBuilder.DropColumn(
                name: "Limit",
                table: "CookingTime");

            migrationBuilder.DropColumn(
                name: "IsAdded",
                table: "Allergies");

            migrationBuilder.DropColumn(
                name: "IsAdded",
                table: "ActivityLevels");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "CookingTime",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(256)",
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "CookingTime",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "InternalName",
                table: "CookingTime",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(256)",
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "CookingTime",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);
        }
    }
}
