using System;
using Microsoft.EntityFrameworkCore.Migrations;

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
            migrationBuilder.CreateTable(
                name: "AllergyCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Title = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllergyCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Difficulty",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Title = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
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
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    Description = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: false),
                    Image = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DishCategories", x => x.Id);
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
                    Price = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: false),
                    Title = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    Description = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: false),
                    Image = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Intolerances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Title = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Intolerances", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MealPlans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
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
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Preferences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: false),
                    Title = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Preferences", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sessions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Phone = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    IpAddress = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    UserAgent = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ExpiresAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsUsed = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    UsedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
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
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserActivityLevels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Title = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserActivityLevels", x => x.Id);
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
                    RefreshTokenExpiry = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Allergies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: false),
                    CategoryId = table.Column<int>(type: "integer", nullable: false),
                    Title = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Allergies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Allergies_AllergyCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "AllergyCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    Price = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: false),
                    Title = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
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
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Dishes_DishCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "DishCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserIntolerances",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    IntoleranceId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserIntolerances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserIntolerances_Intolerances_IntoleranceId",
                        column: x => x.IntoleranceId,
                        principalTable: "Intolerances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserIntolerances_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserPreferences",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    PreferenceId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPreferences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserPreferences_Preferences_PreferenceId",
                        column: x => x.PreferenceId,
                        principalTable: "Preferences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserPreferences_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
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
                        onDelete: ReferentialAction.Cascade);
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
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Meals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
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
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Meals_MealPlans_MealPlanId",
                        column: x => x.MealPlanId,
                        principalTable: "MealPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Meals_MealTypes_MealTypeId",
                        column: x => x.MealTypeId,
                        principalTable: "MealTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AllergyCategories",
                columns: new[] { "Id", "IsDeleted", "Title" },
                values: new object[,]
                {
                    { 1, false, "Пищевая" },
                    { 2, false, "Лекарственная" },
                    { 3, false, "Экологическая" }
                });

            migrationBuilder.InsertData(
                table: "Difficulty",
                columns: new[] { "Id", "IsDeleted", "Title" },
                values: new object[,]
                {
                    { 1, false, "Легко" },
                    { 2, false, "Средне" },
                    { 3, false, "Сложно" }
                });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Calories", "Carbohydrates", "Description", "Fats", "Image", "IsDeleted", "Price", "Proteins", "Title" },
                values: new object[,]
                {
                    { 1, 18m, 3.9m, "Свежий красный помидор", 0.2m, "tomato.jpg", false, 50m, 0.9m, "Помидор" },
                    { 2, 15m, 2.8m, "Свежий зеленый огурец", 0.1m, "cucumber.jpg", false, 40m, 0.8m, "Огурец" },
                    { 3, 40m, 9.3m, "Репчатый лук", 0.1m, "onion.jpg", false, 30m, 1.1m, "Лук репчатый" },
                    { 4, 41m, 9.6m, "Свежая морковь", 0.2m, "carrot.jpg", false, 35m, 0.9m, "Морковь" },
                    { 5, 77m, 17.5m, "Свежий картофель", 0.1m, "potato.jpg", false, 45m, 2.0m, "Картофель" },
                    { 6, 27m, 6.0m, "Сладкий перец", 0.3m, "bell_pepper.jpg", false, 70m, 1.0m, "Болгарский перец" },
                    { 7, 149m, 33.1m, "Свежий чеснок", 0.5m, "garlic.jpg", false, 25m, 6.4m, "Чеснок" },
                    { 8, 25m, 5.8m, "Свежая капуста", 0.1m, "cabbage.jpg", false, 40m, 1.3m, "Капуста белокочанная" },
                    { 9, 34m, 7.0m, "Свежая брокколи", 0.4m, "broccoli.jpg", false, 120m, 2.8m, "Брокколи" },
                    { 10, 25m, 5.0m, "Свежая цветная капуста", 0.3m, "cauliflower.jpg", false, 90m, 2.0m, "Цветная капуста" },
                    { 11, 17m, 3.1m, "Свежий кабачок", 0.3m, "zucchini.jpg", false, 60m, 1.2m, "Кабачок" },
                    { 12, 24m, 5.7m, "Свежий баклажан", 0.2m, "eggplant.jpg", false, 80m, 1.0m, "Баклажан" },
                    { 13, 23m, 3.6m, "Свежий шпинат", 0.4m, "spinach.jpg", false, 100m, 2.9m, "Шпинат" },
                    { 14, 15m, 2.9m, "Свежий салат", 0.2m, "lettuce.jpg", false, 70m, 1.4m, "Салат листовой" },
                    { 15, 16m, 3.0m, "Стебли сельдерея", 0.2m, "celery.jpg", false, 55m, 0.7m, "Сельдерей" },
                    { 16, 52m, 14.0m, "Свежее яблоко", 0.2m, "apple.jpg", false, 60m, 0.3m, "Яблоко" },
                    { 17, 89m, 22.8m, "Спелый банан", 0.3m, "banana.jpg", false, 50m, 1.1m, "Банан" },
                    { 18, 47m, 11.8m, "Свежий апельсин", 0.1m, "orange.jpg", false, 70m, 0.9m, "Апельсин" },
                    { 19, 29m, 9.3m, "Свежий лимон", 0.3m, "lemons.jpg", false, 40m, 1.1m, "Лимон" },
                    { 20, 32m, 7.7m, "Свежая клубника", 0.3m, "strawberry.jpg", false, 150m, 0.7m, "Клубника" },
                    { 21, 57m, 14.5m, "Свежая черника", 0.3m, "blueberry.jpg", false, 200m, 0.7m, "Черника" },
                    { 22, 160m, 9.0m, "Спелый авокадо", 15.0m, "avocado.jpg", false, 180m, 2.0m, "Авокадо" },
                    { 23, 165m, 0.0m, "Филе куриной грудки", 3.6m, "chicken_breast.jpg", false, 200m, 31.0m, "Куриная грудка" },
                    { 24, 209m, 0.0m, "Куриное бедро с кожей", 11.0m, "chicken_thigh.jpg", false, 180m, 26.0m, "Куриное бедро" },
                    { 25, 250m, 0.0m, "Постная говядина", 15.0m, "beef.jpg", false, 350m, 26.0m, "Говядина" },
                    { 26, 242m, 0.0m, "Свиная вырезка", 14.0m, "pork.jpg", false, 300m, 25.0m, "Свинина" },
                    { 27, 135m, 0.0m, "Филе индейки", 3.0m, "turkey.jpg", false, 250m, 29.0m, "Индейка" },
                    { 28, 541m, 1.4m, "Копченый бекон", 42.0m, "bacon.jpg", false, 400m, 37.0m, "Бекон" },
                    { 29, 260m, 2.0m, "Молочные сосиски", 23.0m, "sausage.jpg", false, 180m, 12.0m, "Сосиски" },
                    { 30, 208m, 0.0m, "Филе лосося", 13.0m, "salmon.jpg", false, 500m, 20.0m, "Лосось" },
                    { 31, 184m, 0.0m, "Филе тунца", 6.0m, "tuna.jpg", false, 450m, 30.0m, "Тунец" },
                    { 32, 82m, 0.0m, "Филе трески", 0.7m, "cod.jpg", false, 350m, 18.0m, "Треска" },
                    { 33, 85m, 1.0m, "Очищенные креветки", 1.0m, "shrimp.jpg", false, 400m, 18.0m, "Креветки" },
                    { 34, 86m, 4.0m, "Свежие мидии", 2.0m, "mussels.jpg", false, 300m, 12.0m, "Мидии" },
                    { 35, 61m, 4.8m, "Цельное молоко", 3.6m, "milk.jpg", false, 80m, 3.2m, "Молоко" },
                    { 36, 350m, 1.3m, "Твердый сыр", 27.0m, "cheese.jpg", false, 150m, 25.0m, "Сыр" },
                    { 37, 72m, 3.0m, "Обезжиренный творог", 0.5m, "cottage_cheese.jpg", false, 100m, 16.0m, "Творог" },
                    { 38, 59m, 3.6m, "Греческий йогурт", 0.4m, "yogurt.jpg", false, 90m, 10.0m, "Йогурт" },
                    { 39, 206m, 3.2m, "Сметана 20%", 20.0m, "sour_cream.jpg", false, 70m, 2.8m, "Сметана" },
                    { 40, 717m, 0.1m, "Сливочное масло 82%", 81.0m, "butter.jpg", false, 120m, 0.9m, "Сливочное масло" },
                    { 41, 155m, 1.1m, "Куриные яйца", 11.0m, "eggs.jpg", false, 80m, 13.0m, "Яйца" },
                    { 42, 130m, 28.0m, "Белый рис", 0.3m, "rice.jpg", false, 80m, 2.7m, "Рис" },
                    { 43, 343m, 72.0m, "Гречневая крупа", 3.4m, "buckwheat.jpg", false, 70m, 13.0m, "Гречка" },
                    { 44, 389m, 66.3m, "Овсяные хлопья", 6.9m, "oatmeal.jpg", false, 60m, 16.9m, "Овсянка" },
                    { 45, 131m, 25.0m, "Спагетти", 1.0m, "pasta.jpg", false, 90m, 5.0m, "Макароны" },
                    { 46, 265m, 49.0m, "Пшеничный хлеб", 3.2m, "bread.jpg", false, 50m, 9.0m, "Хлеб" },
                    { 47, 364m, 76.0m, "Пшеничная мука", 1.0m, "flour.jpg", false, 60m, 10.0m, "Мука" },
                    { 48, 139m, 25.0m, "Консервированная фасоль", 0.5m, "beans.jpg", false, 100m, 9.0m, "Фасоль" },
                    { 49, 116m, 20.0m, "Красная чечевица", 0.4m, "lentils.jpg", false, 110m, 9.0m, "Чечевица" },
                    { 50, 81m, 14.0m, "Зеленый горошек", 0.4m, "peas.jpg", false, 70m, 5.0m, "Горох" },
                    { 51, 579m, 22.0m, "Сырой миндаль", 50.0m, "almonds.jpg", false, 300m, 21.0m, "Миндаль" },
                    { 52, 654m, 14.0m, "Ядра грецких орехов", 65.0m, "walnuts.jpg", false, 250m, 15.0m, "Грецкие орехи" },
                    { 53, 567m, 16.0m, "Жареный арахис", 49.0m, "peanuts.jpg", false, 200m, 26.0m, "Арахис" },
                    { 54, 884m, 0.0m, "Extra virgin", 100.0m, "olive_oil.jpg", false, 300m, 0.0m, "Оливковое масло" },
                    { 55, 884m, 0.0m, "Рафинированное", 100.0m, "sunflower_oil.jpg", false, 150m, 0.0m, "Подсолнечное масло" },
                    { 56, 862m, 0.0m, "Органическое", 100.0m, "coconut_oil.jpg", false, 250m, 0.0m, "Кокосовое масло" },
                    { 57, 0m, 0.0m, "Поваренная соль", 0.0m, "salt.jpg", false, 20m, 0.0m, "Соль" },
                    { 58, 251m, 64.0m, "Молотый перец", 3.3m, "black_pepper.jpg", false, 30m, 10.0m, "Черный перец" },
                    { 59, 387m, 100.0m, "Белый сахар", 0.0m, "sugar.jpg", false, 40m, 0.0m, "Сахар" },
                    { 60, 304m, 82.0m, "Натуральный мед", 0.0m, "honey.jpg", false, 200m, 0.3m, "Мед" },
                    { 61, 18m, 0.9m, "Яблочный уксус", 0.0m, "vinegar.jpg", false, 80m, 0.0m, "Уксус" },
                    { 62, 53m, 5.0m, "Темный соевый соус", 0.0m, "soy_sauce.jpg", false, 120m, 8.0m, "Соевый соус" },
                    { 63, 101m, 25.0m, "Томатный кетчуп", 0.3m, "ketchup.jpg", false, 90m, 1.8m, "Кетчуп" },
                    { 64, 680m, 2.6m, "Классический майонез", 75.0m, "mayonnaise.jpg", false, 100m, 1.0m, "Майонез" },
                    { 65, 23m, 2.7m, "Свежий базилик", 0.6m, "basil.jpg", false, 60m, 3.2m, "Базилик" },
                    { 66, 36m, 6.3m, "Свежая петрушка", 0.8m, "parsley.jpg", false, 40m, 3.0m, "Петрушка" },
                    { 67, 43m, 7.0m, "Свежий укроп", 1.1m, "dill.jpg", false, 35m, 3.5m, "Укроп" },
                    { 68, 23m, 3.7m, "Свежая кинза", 0.5m, "cilantro.jpg", false, 45m, 2.1m, "Кинза" },
                    { 69, 70m, 14.9m, "Свежая мята", 0.9m, "mint.jpg", false, 50m, 3.8m, "Мята" },
                    { 70, 1m, 0.0m, "Молотый кофе", 0.0m, "coffee.jpg", false, 250m, 0.1m, "Кофе" },
                    { 71, 1m, 0.3m, "Черный чай", 0.0m, "tea.jpg", false, 150m, 0.0m, "Чай" },
                    { 72, 0m, 0.0m, "Питьевая вода", 0.0m, "water.jpg", false, 20m, 0.0m, "Вода" },
                    { 73, 82m, 19.0m, "Концентрированная паста", 0.5m, "tomato_paste.jpg", false, 70m, 4.3m, "Томатная паста" },
                    { 74, 86m, 19.0m, "Сладкая кукуруза", 1.2m, "canned_corn.jpg", false, 80m, 3.3m, "Кукуруза консервированная" },
                    { 75, 69m, 12.0m, "Зеленый горошек", 0.4m, "canned_peas.jpg", false, 75m, 4.4m, "Горошек консервированный" },
                    { 76, 115m, 6.0m, "Консервированные оливки", 11.0m, "olives.jpg", false, 120m, 0.8m, "Оливки" },
                    { 77, 11m, 2.3m, "Соленые огурцы", 0.1m, "pickles.jpg", false, 60m, 0.6m, "Огурцы маринованные" },
                    { 78, 546m, 61.0m, "Темный шоколад", 31.0m, "chocolate.jpg", false, 180m, 4.9m, "Шоколад" },
                    { 79, 288m, 13.0m, "Ванильный экстракт", 0.1m, "vanilla.jpg", false, 200m, 0.1m, "Ваниль" },
                    { 80, 247m, 81.0m, "Молотая корица", 1.2m, "cinnamon.jpg", false, 90m, 4.0m, "Корица" },
                    { 81, 22m, 3.3m, "Свежие шампиньоны", 0.3m, "mushrooms.jpg", false, 120m, 3.1m, "Грибы" },
                    { 82, 80m, 18.0m, "Свежий корень имбиря", 0.8m, "ginger.jpg", false, 100m, 1.8m, "Имбирь" },
                    { 83, 40m, 9.0m, "Острый перец", 0.2m, "chili.jpg", false, 60m, 2.0m, "Перец чили" },
                    { 84, 86m, 19.0m, "Свежая кукуруза", 1.2m, "corn.jpg", false, 50m, 3.3m, "Кукуруза" },
                    { 85, 43m, 9.6m, "Свежая свекла", 0.2m, "beetroot.jpg", false, 40m, 1.6m, "Свекла" },
                    { 86, 16m, 3.4m, "Свежий редис", 0.1m, "radish.jpg", false, 35m, 0.7m, "Редис" },
                    { 87, 20m, 3.9m, "Свежая спаржа", 0.1m, "asparagus.jpg", false, 180m, 2.2m, "Спаржа" },
                    { 88, 47m, 10.5m, "Свежий артишок", 0.2m, "artichoke.jpg", false, 200m, 3.3m, "Артишок" },
                    { 89, 50m, 13.0m, "Свежий ананас", 0.1m, "pineapple.jpg", false, 150m, 0.5m, "Ананас" },
                    { 90, 60m, 15.0m, "Спелое манго", 0.4m, "mango.jpg", false, 170m, 0.8m, "Манго" },
                    { 91, 61m, 14.7m, "Свежий киви", 0.5m, "kiwi.jpg", false, 100m, 1.1m, "Киви" },
                    { 92, 83m, 19.0m, "Спелый гранат", 1.2m, "pomegranate.jpg", false, 220m, 1.7m, "Гранат" },
                    { 93, 282m, 75.0m, "Сушеные финики", 0.4m, "dates.jpg", false, 180m, 2.5m, "Финики" },
                    { 94, 299m, 79.0m, "Сушеный виноград", 0.5m, "raisins.jpg", false, 120m, 3.1m, "Изюм" },
                    { 95, 354m, 15.0m, "Свежий кокос", 33.0m, "coconut.jpg", false, 250m, 3.3m, "Кокос" },
                    { 96, 573m, 23.0m, "Семена кунжута", 50.0m, "sesame.jpg", false, 140m, 18.0m, "Кунжут" },
                    { 97, 584m, 20.0m, "Жареные семечки", 51.0m, "sunflower_seeds.jpg", false, 100m, 21.0m, "Семечки подсолнечника" },
                    { 98, 66m, 5.8m, "Дижонская горчица", 3.3m, "mustard.jpg", false, 80m, 4.4m, "Горчица" },
                    { 99, 48m, 11.3m, "Тертый хрен", 0.1m, "horseradish.jpg", false, 90m, 1.2m, "Хрен" },
                    { 100, 260m, 67.0m, "Натуральный сироп", 0.1m, "maple_syrup.jpg", false, 300m, 0.0m, "Кленовый сироп" }
                });

            migrationBuilder.InsertData(
                table: "Intolerances",
                columns: new[] { "Id", "IsDeleted", "Title" },
                values: new object[,]
                {
                    { 1, false, "Лактоза" },
                    { 2, false, "Глютен" },
                    { 3, false, "Фруктоза" },
                    { 4, false, "Гистамин" },
                    { 5, false, "Сорбитол" },
                    { 6, false, "Глютен (целиакия)" },
                    { 7, false, "Фруктаны" },
                    { 8, false, "Галактоза" },
                    { 9, false, "Казеин" },
                    { 10, false, "Дрожжи" }
                });

            migrationBuilder.InsertData(
                table: "MealTypes",
                columns: new[] { "Id", "IsDeleted", "Title" },
                values: new object[,]
                {
                    { 1, false, "Завтрак" },
                    { 2, false, "Обед" },
                    { 3, false, "Перекус" },
                    { 4, false, "Ужин" }
                });

            migrationBuilder.InsertData(
                table: "Preferences",
                columns: new[] { "Id", "Description", "IsDeleted", "Title" },
                values: new object[,]
                {
                    { 1, "Исключение мяса, но допущение молочных продуктов и яиц", false, "Вегетарианство" },
                    { 2, "Полное исключение продуктов животного происхождения", false, "Веганство" },
                    { 3, "Исключение мяса, но допущение рыбы и морепродуктов", false, "Пескетарианство" },
                    { 4, "Исключение красного мяса, но допущение птицы", false, "Поллотарианство" },
                    { 5, "Преимущественно растительная диета с редким употреблением мяса", false, "Флекситарианство" },
                    { 6, "Исключение глютеносодержащих продуктов", false, "Безглютеновая диета" },
                    { 7, "Диета древних людей - мясо, рыба, овощи, орехи", false, "Палео диета" },
                    { 8, "Низкоуглеводная высокожировая диета", false, "Кето диета" },
                    { 9, "Ограничение углеводов в рационе", false, "Низкоуглеводная диета" },
                    { 10, "Диета на основе овощей, фруктов, оливкового масла", false, "Средиземноморская диета" },
                    { 11, "Предпочтение органически выращенным продуктам", false, "Органические продукты" },
                    { 12, "Предпочтение местным производителям", false, "Локальные продукты" },
                    { 13, "Предпочтение сезонным фруктам и овощам", false, "Сезонные продукты" },
                    { 14, "Поддержка fair trade продуктов", false, "Справедливая торговля" },
                    { 15, "Продукты, не тестированные на животных", false, "Без жестокости" },
                    { 16, "Исключение алкогольных напитков", false, "Без алкоголя" },
                    { 17, "Исключение кофеиносодержащих продуктов", false, "Без кофеина" },
                    { 18, "Ограничение натрия в рационе", false, "Низкое содержание соли" },
                    { 19, "Ограничение сахара в рационе", false, "Низкое содержание сахара" },
                    { 20, "Увеличение потребления белка", false, "Высокобелковая диета" }
                });

            migrationBuilder.InsertData(
                table: "Units",
                columns: new[] { "Id", "IsDeleted", "ShortTitle", "Title" },
                values: new object[,]
                {
                    { 1, false, "г.", "Грамм" },
                    { 2, false, "кг.", "Килограмм" },
                    { 3, false, "шт.", "Штук" },
                    { 4, false, "мл.", "Миллилитр" },
                    { 5, false, "л.", "Литр" },
                    { 6, false, "ст. л.", "Столовая ложка" },
                    { 7, false, "ч. л.", "Чайная ложка" },
                    { 8, false, "ломтика", "Ломтик" }
                });

            migrationBuilder.InsertData(
                table: "UserActivityLevels",
                columns: new[] { "Id", "IsDeleted", "Title" },
                values: new object[,]
                {
                    { 1, false, "Сидячий образ жизни" },
                    { 2, false, "Низкая активность" },
                    { 3, false, "Умеренная активность" },
                    { 4, false, "Высокая активность" },
                    { 5, false, "Очень высокая активность" }
                });

            migrationBuilder.InsertData(
                table: "Allergies",
                columns: new[] { "Id", "CategoryId", "Description", "IsDeleted", "Title" },
                values: new object[,]
                {
                    { 1, 1, "Аллергия на арахис и продукты содержащие арахис", false, "Арахис" },
                    { 2, 1, "Аллергия на белок коровьего молока", false, "Молоко" },
                    { 3, 1, "Аллергия на яичный белок", false, "Яйца" },
                    { 4, 1, "Аллергия на рыбу и морепродукты", false, "Рыба" },
                    { 5, 1, "Аллергия на креветки, крабы, лобстеры", false, "Ракообразные" },
                    { 6, 1, "Аллергия на лесные орехи (грецкие, миндаль, кешью)", false, "Орехи" },
                    { 7, 1, "Аллергия на белок пшеницы", false, "Пшеница" },
                    { 8, 1, "Аллергия на соевые продукты", false, "Соя" },
                    { 9, 1, "Аллергия на семена кунжута", false, "Кунжут" },
                    { 10, 1, "Аллергия на киви", false, "Киви" },
                    { 11, 2, "Аллергия на антибиотики пенициллинового ряда", false, "Пенициллин" },
                    { 12, 2, "Аллергия на ацетилсалициловую кислоту", false, "Аспирин" },
                    { 13, 2, "Аллергия на нестероидные противовоспалительные", false, "Ибупрофен" },
                    { 14, 2, "Аллергия на сульфа drugs", false, "Сульфаниламиды" },
                    { 15, 3, "Сезонная аллергия на пыльцу березы", false, "Пыльца березы" },
                    { 16, 3, "Сезонная аллергия на амброзию", false, "Пыльца амброзии" },
                    { 17, 3, "Аллергия на домашних пылевых клещей", false, "Пылевые клещи" },
                    { 18, 3, "Аллергия на кошачью шерсть", false, "Шерсть кошек" },
                    { 19, 3, "Аллергия на собачью шерсть", false, "Шерсть собак" },
                    { 20, 3, "Аллергия на плесневые грибы", false, "Плесень" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Allergies_CategoryId",
                table: "Allergies",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Dishes_CategoryId",
                table: "Dishes",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Dishes_DifficultyId",
                table: "Dishes",
                column: "DifficultyId");

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
                name: "IX_Sessions_Phone",
                table: "Sessions",
                column: "Phone");

            migrationBuilder.CreateIndex(
                name: "IX_UserAllergies_AllergyId",
                table: "UserAllergies",
                column: "AllergyId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAllergies_UserId",
                table: "UserAllergies",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserIntolerances_IntoleranceId",
                table: "UserIntolerances",
                column: "IntoleranceId");

            migrationBuilder.CreateIndex(
                name: "IX_UserIntolerances_UserId",
                table: "UserIntolerances",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPreferences_PreferenceId",
                table: "UserPreferences",
                column: "PreferenceId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPreferences_UserId",
                table: "UserPreferences",
                column: "UserId");

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
                name: "DishIngredients");

            migrationBuilder.DropTable(
                name: "Meals");

            migrationBuilder.DropTable(
                name: "Sessions");

            migrationBuilder.DropTable(
                name: "UserActivityLevels");

            migrationBuilder.DropTable(
                name: "UserAllergies");

            migrationBuilder.DropTable(
                name: "UserIntolerances");

            migrationBuilder.DropTable(
                name: "UserPreferences");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "Units");

            migrationBuilder.DropTable(
                name: "Dishes");

            migrationBuilder.DropTable(
                name: "MealPlans");

            migrationBuilder.DropTable(
                name: "MealTypes");

            migrationBuilder.DropTable(
                name: "Allergies");

            migrationBuilder.DropTable(
                name: "Intolerances");

            migrationBuilder.DropTable(
                name: "Preferences");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Difficulty");

            migrationBuilder.DropTable(
                name: "DishCategories");

            migrationBuilder.DropTable(
                name: "AllergyCategories");
        }
    }
}
