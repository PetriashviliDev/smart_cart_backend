using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Pgvector;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SmartCartBackend.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:vector", ",,");

            migrationBuilder.CreateTable(
                name: "ActivityLevels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Title = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    InternalName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityLevels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CookingTime",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: true),
                    InternalName = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CookingTime", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DietStrategies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Title = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    InternalName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Image = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DietStrategies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Difficulty",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Title = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    InternalName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Difficulty", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DishCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Title = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    InternalName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    Description = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: false),
                    Image = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DishCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FoodRation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: true),
                    InternalName = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodRation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Calories = table.Column<decimal>(type: "numeric", nullable: false),
                    Proteins = table.Column<decimal>(type: "numeric", nullable: false),
                    Fats = table.Column<decimal>(type: "numeric", nullable: false),
                    Carbohydrates = table.Column<decimal>(type: "numeric", nullable: false),
                    Price = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: true),
                    Title = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    InternalName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    Description = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: false),
                    Image = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MealPlans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    StartDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealPlans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MealTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Title = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    InternalName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PhoneVerifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Phone = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    Code = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    ExpiresAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    IsConfirmed = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    ConfirmedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneVerifications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sessions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Phone = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    IpAddress = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    UserAgent = table.Column<string>(type: "character varying(1024)", maxLength: 1024, nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    ExpiresAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    IsUsed = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    UsedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    ShortTitle = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    Title = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    InternalName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    Phone = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    Gender = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    Age = table.Column<int>(type: "integer", nullable: false),
                    Height = table.Column<double>(type: "double precision", precision: 10, scale: 1, nullable: false),
                    Weight = table.Column<double>(type: "double precision", precision: 10, scale: 1, nullable: false),
                    RefreshTokenHash = table.Column<string>(type: "text", nullable: false),
                    RefreshTokenExpiry = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Intolerances = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: true),
                    ActivityLevelId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_ActivityLevels_ActivityLevelId",
                        column: x => x.ActivityLevelId,
                        principalTable: "ActivityLevels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Dishes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Recipe = table.Column<string>(type: "text", nullable: false),
                    CookingTime = table.Column<int>(type: "integer", nullable: false),
                    DifficultyId = table.Column<int>(type: "integer", nullable: false),
                    CategoryId = table.Column<int>(type: "integer", nullable: false),
                    Portions = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: true),
                    Title = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    InternalName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    Description = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: false),
                    Image = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dishes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dishes_Difficulty_DifficultyId",
                        column: x => x.DifficultyId,
                        principalTable: "Difficulty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Dishes_DishCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "DishCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Allergies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    IngredientId = table.Column<int>(type: "integer", nullable: true),
                    Title = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    InternalName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Allergies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Allergies_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserAiRequests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Provider = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    Model = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    RequestedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DurationMs = table.Column<long>(type: "bigint", nullable: false),
                    Status = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    ErrorText = table.Column<string>(type: "text", nullable: true),
                    PromptTokens = table.Column<int>(type: "integer", nullable: true),
                    CompletionTokens = table.Column<int>(type: "integer", nullable: true),
                    TotalTokens = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAiRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAiRequests_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DishEmbeddings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DishId = table.Column<int>(type: "integer", nullable: false),
                    Model = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    Dimensions = table.Column<int>(type: "integer", nullable: false, defaultValue: 384),
                    TextVersion = table.Column<int>(type: "integer", nullable: false),
                    ContentHash = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Embedding = table.Column<Vector>(type: "vector(384)", nullable: false),
                    DishId1 = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DishEmbeddings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DishEmbeddings_Dishes_DishId",
                        column: x => x.DishId,
                        principalTable: "Dishes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DishEmbeddings_Dishes_DishId1",
                        column: x => x.DishId1,
                        principalTable: "Dishes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DishIngredients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    UnitId = table.Column<int>(type: "integer", nullable: false),
                    DishId = table.Column<int>(type: "integer", nullable: false),
                    IngredientId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DishIngredients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DishIngredients_Dishes_DishId",
                        column: x => x.DishId,
                        principalTable: "Dishes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DishIngredients_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DishIngredients_Units_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Meals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    MealTypeId = table.Column<int>(type: "integer", nullable: false),
                    DishId = table.Column<int>(type: "integer", nullable: false),
                    MealPlanId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Meals_Dishes_DishId",
                        column: x => x.DishId,
                        principalTable: "Dishes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Meals_MealPlans_MealPlanId",
                        column: x => x.MealPlanId,
                        principalTable: "MealPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Meals_MealTypes_MealTypeId",
                        column: x => x.MealTypeId,
                        principalTable: "MealTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserPreferences",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    DishId = table.Column<int>(type: "integer", nullable: false),
                    MealTypeId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPreferences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserPreferences_Dishes_DishId",
                        column: x => x.DishId,
                        principalTable: "Dishes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserPreferences_MealTypes_MealTypeId",
                        column: x => x.MealTypeId,
                        principalTable: "MealTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserPreferences_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IngredientAllergies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    IngredientId = table.Column<int>(type: "integer", nullable: false),
                    AllergyId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientAllergies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IngredientAllergies_Allergies_AllergyId",
                        column: x => x.AllergyId,
                        principalTable: "Allergies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IngredientAllergies_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserAllergies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    AllergyId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAllergies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAllergies_Allergies_AllergyId",
                        column: x => x.AllergyId,
                        principalTable: "Allergies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserAllergies_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "ActivityLevels",
                columns: new[] { "Id", "InternalName", "Title" },
                values: new object[,]
                {
                    { 1, "sedentary", "Сидячий образ жизни" },
                    { 2, "lightly_active", "1-3 тренировки" },
                    { 3, "moderately_active", "4-5 тренировок" },
                    { 4, "very_active", "6-7 тренировок" },
                    { 5, "professional_active", "Профессиональный спорт" }
                });

            migrationBuilder.InsertData(
                table: "Allergies",
                columns: new[] { "Id", "IngredientId", "InternalName", "Title" },
                values: new object[,]
                {
                    { 1, null, "peanut", "Арахис" },
                    { 2, null, "milk", "Молочное" },
                    { 3, null, "eggs", "Яйца" },
                    { 4, null, "gluten", "Глютен" }
                });

            migrationBuilder.InsertData(
                table: "CookingTime",
                columns: new[] { "Id", "InternalName", "IsDeleted", "Title" },
                values: new object[,]
                {
                    { 1, "small", false, "До 15 мин" },
                    { 2, "medium", false, "15-30 мин" },
                    { 3, "hard", false, "30-60 мин" },
                    { 4, "unlimited", false, "Не ограничено" }
                });

            migrationBuilder.InsertData(
                table: "DietStrategies",
                columns: new[] { "Id", "Description", "Image", "InternalName", "Title" },
                values: new object[,]
                {
                    { 1, "Сохранить текущий вес и тонус", null, "form_maintenance", "Поддержание формы" },
                    { 2, "Увеличение мышечной массы и силы", null, "muscle_gain", "Набор массы" },
                    { 3, "Вкусные и разные блюда каждый день", null, "varied_diet", "Просто разнообразить питание" },
                    { 4, "Постепенное и комфортное похудение", null, "weight_loss", "Снижение веса" }
                });

            migrationBuilder.InsertData(
                table: "Difficulty",
                columns: new[] { "Id", "InternalName", "Title" },
                values: new object[,]
                {
                    { 1, "easy", "Легко" },
                    { 2, "normal", "Средне" },
                    { 3, "hard", "Сложно" }
                });

            migrationBuilder.InsertData(
                table: "FoodRation",
                columns: new[] { "Id", "InternalName", "IsDeleted", "Title" },
                values: new object[,]
                {
                    { 1, "three_main", false, "3 основных" },
                    { 2, "three_main_and_one_snack", false, "3 основных + 1 перекус" },
                    { 3, "three_main_and_two_snack", false, "3 основных + 2 перекуса" },
                    { 4, "interval_fasting", false, "2 раза в день (интервальное голодание)" }
                });

            migrationBuilder.InsertData(
                table: "MealTypes",
                columns: new[] { "Id", "InternalName", "Title" },
                values: new object[,]
                {
                    { 1, "breakfast", "Завтрак" },
                    { 2, "lunch", "Обед" },
                    { 3, "snack", "Перекус" },
                    { 4, "dinner", "Ужин" }
                });

            migrationBuilder.InsertData(
                table: "Units",
                columns: new[] { "Id", "InternalName", "ShortTitle", "Title" },
                values: new object[,]
                {
                    { 1, "gram", "г.", "Грамм" },
                    { 2, "kilogram", "кг.", "Килограмм" },
                    { 3, "piece", "шт.", "Штук" },
                    { 4, "milliliter", "мл.", "Миллилитр" },
                    { 5, "liter", "л.", "Литр" },
                    { 6, "tablespoon", "ст. л.", "Столовая ложка" },
                    { 7, "teaspoon", "ч. л.", "Чайная ложка" },
                    { 8, "slice", "ломтика", "Ломтик" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActivityLevels_InternalName",
                table: "ActivityLevels",
                column: "InternalName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Allergies_IngredientId",
                table: "Allergies",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_Allergies_InternalName",
                table: "Allergies",
                column: "InternalName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DietStrategies_InternalName",
                table: "DietStrategies",
                column: "InternalName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Difficulty_InternalName",
                table: "Difficulty",
                column: "InternalName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DishCategories_InternalName",
                table: "DishCategories",
                column: "InternalName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DishEmbeddings_DishId",
                table: "DishEmbeddings",
                column: "DishId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DishEmbeddings_DishId1",
                table: "DishEmbeddings",
                column: "DishId1",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DishEmbeddings_Model",
                table: "DishEmbeddings",
                column: "Model");

            migrationBuilder.CreateIndex(
                name: "IX_DishEmbeddings_Model_TextVersion",
                table: "DishEmbeddings",
                columns: new[] { "Model", "TextVersion" });

            migrationBuilder.CreateIndex(
                name: "IX_Dishes_CategoryId",
                table: "Dishes",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Dishes_DifficultyId",
                table: "Dishes",
                column: "DifficultyId");

            migrationBuilder.CreateIndex(
                name: "IX_Dishes_InternalName",
                table: "Dishes",
                column: "InternalName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DishIngredients_DishId_IngredientId",
                table: "DishIngredients",
                columns: new[] { "DishId", "IngredientId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DishIngredients_IngredientId",
                table: "DishIngredients",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_DishIngredients_UnitId",
                table: "DishIngredients",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientAllergies_AllergyId",
                table: "IngredientAllergies",
                column: "AllergyId");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientAllergies_IngredientId_AllergyId",
                table: "IngredientAllergies",
                columns: new[] { "IngredientId", "AllergyId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_InternalName",
                table: "Ingredients",
                column: "InternalName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Meals_Date",
                table: "Meals",
                column: "Date");

            migrationBuilder.CreateIndex(
                name: "IX_Meals_DishId",
                table: "Meals",
                column: "DishId");

            migrationBuilder.CreateIndex(
                name: "IX_Meals_MealPlanId_Date",
                table: "Meals",
                columns: new[] { "MealPlanId", "Date" });

            migrationBuilder.CreateIndex(
                name: "IX_Meals_MealTypeId",
                table: "Meals",
                column: "MealTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MealTypes_InternalName",
                table: "MealTypes",
                column: "InternalName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PhoneVerifications_Phone",
                table: "PhoneVerifications",
                column: "Phone");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_Phone",
                table: "Sessions",
                column: "Phone");

            migrationBuilder.CreateIndex(
                name: "IX_Units_InternalName",
                table: "Units",
                column: "InternalName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserAiRequests_Provider_Model_RequestedAt",
                table: "UserAiRequests",
                columns: new[] { "Provider", "Model", "RequestedAt" });

            migrationBuilder.CreateIndex(
                name: "IX_UserAiRequests_Status_RequestedAt",
                table: "UserAiRequests",
                columns: new[] { "Status", "RequestedAt" });

            migrationBuilder.CreateIndex(
                name: "IX_UserAiRequests_UserId_RequestedAt",
                table: "UserAiRequests",
                columns: new[] { "UserId", "RequestedAt" });

            migrationBuilder.CreateIndex(
                name: "IX_UserAllergies_AllergyId",
                table: "UserAllergies",
                column: "AllergyId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAllergies_UserId",
                table: "UserAllergies",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPreferences_DishId",
                table: "UserPreferences",
                column: "DishId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPreferences_MealTypeId",
                table: "UserPreferences",
                column: "MealTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPreferences_UserId",
                table: "UserPreferences",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ActivityLevelId",
                table: "Users",
                column: "ActivityLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Phone",
                table: "Users",
                column: "Phone",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CookingTime");

            migrationBuilder.DropTable(
                name: "DietStrategies");

            migrationBuilder.DropTable(
                name: "DishEmbeddings");

            migrationBuilder.DropTable(
                name: "DishIngredients");

            migrationBuilder.DropTable(
                name: "FoodRation");

            migrationBuilder.DropTable(
                name: "IngredientAllergies");

            migrationBuilder.DropTable(
                name: "Meals");

            migrationBuilder.DropTable(
                name: "PhoneVerifications");

            migrationBuilder.DropTable(
                name: "Sessions");

            migrationBuilder.DropTable(
                name: "UserAiRequests");

            migrationBuilder.DropTable(
                name: "UserAllergies");

            migrationBuilder.DropTable(
                name: "UserPreferences");

            migrationBuilder.DropTable(
                name: "Units");

            migrationBuilder.DropTable(
                name: "MealPlans");

            migrationBuilder.DropTable(
                name: "Allergies");

            migrationBuilder.DropTable(
                name: "Dishes");

            migrationBuilder.DropTable(
                name: "MealTypes");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "Difficulty");

            migrationBuilder.DropTable(
                name: "DishCategories");

            migrationBuilder.DropTable(
                name: "ActivityLevels");
        }
    }
}
