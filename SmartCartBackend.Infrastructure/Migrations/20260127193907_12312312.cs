using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartCartBackend.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _12312312 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Group",
                table: "NutritionPlanChoices",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "NutritionPlanChoices",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Group",
                table: "NutritionPlanChoices");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "NutritionPlanChoices");
        }
    }
}
