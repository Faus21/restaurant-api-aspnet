using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RestaurantApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    CityId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("City_pk", x => x.CityId);
                });

            migrationBuilder.CreateTable(
                name: "Dish",
                columns: table => new
                {
                    DishId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DishName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Dish_pk", x => x.DishId);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    PersonId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Surname = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Person_pk", x => x.PersonId);
                });

            migrationBuilder.CreateTable(
                name: "Restaurant",
                columns: table => new
                {
                    RestaurantId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Places = table.Column<int>(type: "integer", nullable: false),
                    CityId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Restaurant_pk", x => x.RestaurantId);
                    table.ForeignKey(
                        name: "Restaurant_City",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    ClientId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PersonId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Client_pk", x => x.ClientId);
                    table.ForeignKey(
                        name: "Client_Person",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Worker",
                columns: table => new
                {
                    WorkerId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PersonId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Worker_pk", x => x.WorkerId);
                    table.ForeignKey(
                        name: "Worker_Person",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "integer", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ClientId = table.Column<int>(type: "integer", nullable: false),
                    WorkerId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Order_pk", x => x.OrderId);
                    table.ForeignKey(
                        name: "Order_Client",
                        column: x => x.OrderId,
                        principalTable: "Client",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "Order_Worker",
                        column: x => x.OrderId,
                        principalTable: "Worker",
                        principalColumn: "WorkerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RestaurantWorker",
                columns: table => new
                {
                    RestaurantWorkerId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RestaurantId = table.Column<int>(type: "integer", nullable: false),
                    WorkerId = table.Column<int>(type: "integer", nullable: false),
                    HireDate = table.Column<DateOnly>(type: "date", nullable: false),
                    DismissalDate = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("RestaurantWorker_pk", x => x.RestaurantWorkerId);
                    table.ForeignKey(
                        name: "RestaurantWorker_Restaurant",
                        column: x => x.WorkerId,
                        principalTable: "Restaurant",
                        principalColumn: "RestaurantId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "RestaurantWorker_Worker",
                        column: x => x.WorkerId,
                        principalTable: "Worker",
                        principalColumn: "WorkerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDish",
                columns: table => new
                {
                    DishId = table.Column<int>(type: "integer", nullable: false),
                    OrderId = table.Column<int>(type: "integer", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("OrderDish_pk", x => new { x.OrderId, x.DishId });
                    table.ForeignKey(
                        name: "FK_OrderDish_Dish_DishId",
                        column: x => x.DishId,
                        principalTable: "Dish",
                        principalColumn: "DishId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDish_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "CityId", "Name" },
                values: new object[,]
                {
                    { 1, "Paris" },
                    { 2, "Warsaw" }
                });

            migrationBuilder.InsertData(
                table: "Dish",
                columns: new[] { "DishId", "DishName" },
                values: new object[,]
                {
                    { 1, "Tomato Soup" },
                    { 2, "Fries" }
                });

            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "PersonId", "Email", "Name", "PhoneNumber", "Surname" },
                values: new object[,]
                {
                    { 1, "john@example.com", "John", "1111111111", "Example" },
                    { 2, "lola@example.com", "Lola", "1111111112", "Example" }
                });

            migrationBuilder.InsertData(
                table: "Client",
                columns: new[] { "ClientId", "PersonId" },
                values: new object[] { 1, 2 });

            migrationBuilder.InsertData(
                table: "Restaurant",
                columns: new[] { "RestaurantId", "CityId", "Places" },
                values: new object[,]
                {
                    { 1, 1, 50 },
                    { 2, 2, 120 }
                });

            migrationBuilder.InsertData(
                table: "Worker",
                columns: new[] { "WorkerId", "PersonId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "OrderId", "ClientId", "OrderDate", "WorkerId" },
                values: new object[] { 1, 1, new DateTime(2024, 7, 10, 11, 9, 13, 208, DateTimeKind.Utc).AddTicks(378), 1 });

            migrationBuilder.InsertData(
                table: "RestaurantWorker",
                columns: new[] { "RestaurantWorkerId", "DismissalDate", "HireDate", "RestaurantId", "WorkerId" },
                values: new object[,]
                {
                    { 1, new DateOnly(9999, 12, 31), new DateOnly(1, 1, 1), 1, 1 },
                    { 2, null, new DateOnly(1, 1, 1), 2, 1 }
                });

            migrationBuilder.InsertData(
                table: "OrderDish",
                columns: new[] { "DishId", "OrderId", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, 4 },
                    { 2, 1, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Client_PersonId",
                table: "Client",
                column: "PersonId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderDish_DishId",
                table: "OrderDish",
                column: "DishId");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurant_CityId",
                table: "Restaurant",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantWorker_WorkerId",
                table: "RestaurantWorker",
                column: "WorkerId");

            migrationBuilder.CreateIndex(
                name: "IX_Worker_PersonId",
                table: "Worker",
                column: "PersonId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDish");

            migrationBuilder.DropTable(
                name: "RestaurantWorker");

            migrationBuilder.DropTable(
                name: "Dish");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Restaurant");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "Worker");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "Person");
        }
    }
}
