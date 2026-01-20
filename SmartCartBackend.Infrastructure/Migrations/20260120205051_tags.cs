using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartCartBackend.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class tags : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DishIngredients_Dishes_DishId",
                table: "DishIngredients");

            migrationBuilder.RenameColumn(
                name: "Intolerances",
                table: "Users",
                newName: "ExcludedProducts");

            migrationBuilder.AddColumn<int>(
                name: "MealTypeId",
                table: "Dishes",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Title = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    InternalName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    IsAdded = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DishTags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    DishId = table.Column<int>(type: "integer", nullable: false),
                    TagId = table.Column<int>(type: "integer", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: true),
                    InternalName = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    IsAdded = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DishTags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DishTags_Dishes_DishId",
                        column: x => x.DishId,
                        principalTable: "Dishes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DishTags_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dishes_MealTypeId",
                table: "Dishes",
                column: "MealTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DishTags_DishId_TagId",
                table: "DishTags",
                columns: new[] { "DishId", "TagId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DishTags_TagId",
                table: "DishTags",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_InternalName",
                table: "Tags",
                column: "InternalName",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Dishes_MealTypes_MealTypeId",
                table: "Dishes",
                column: "MealTypeId",
                principalTable: "MealTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DishIngredients_Dishes_DishId",
                table: "DishIngredients",
                column: "DishId",
                principalTable: "Dishes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dishes_MealTypes_MealTypeId",
                table: "Dishes");

            migrationBuilder.DropForeignKey(
                name: "FK_DishIngredients_Dishes_DishId",
                table: "DishIngredients");

            migrationBuilder.DropTable(
                name: "DishTags");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_Dishes_MealTypeId",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "MealTypeId",
                table: "Dishes");

            migrationBuilder.RenameColumn(
                name: "ExcludedProducts",
                table: "Users",
                newName: "Intolerances");

            migrationBuilder.AddForeignKey(
                name: "FK_DishIngredients_Dishes_DishId",
                table: "DishIngredients",
                column: "DishId",
                principalTable: "Dishes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
