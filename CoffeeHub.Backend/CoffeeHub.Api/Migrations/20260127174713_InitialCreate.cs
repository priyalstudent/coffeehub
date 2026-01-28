using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CoffeeHub.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(8,2)", precision: 8, scale: 2, nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    ProductId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => new { x.OrderId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Products_ProductId1",
                        column: x => x.ProductId1,
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Image", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "A rich and bold espresso made from premium Arabica beans, perfect for strong coffee lovers.", "https://coffeehubimg02.blob.core.windows.net/product-images/ExpressoCoffee.png", "Classic Espresso", 6.99m },
                    { 2, "Smooth coffee infused with warm hazelnut notes for a nutty and comforting flavor.", "https://coffeehubimg02.blob.core.windows.net/product-images/HazelnutCoffee.png", "Hazelnut Coffee", 7.49m },
                    { 3, "A balanced coffee blend with subtle vanilla sweetness for a smooth, aromatic cup.", "https://coffeehubimg02.blob.core.windows.net/product-images/VanilaCoffee.png", "Vanilla Brew", 7.29m },
                    { 4, "Medium-roasted coffee with buttery caramel undertones and a naturally sweet finish.", "https://coffeehubimg02.blob.core.windows.net/product-images/CaramelCoffee.png", "Caramel Roast", 7.59m },
                    { 5, "A deep coffee blend combined with chocolate notes for a rich and indulgent taste.", "https://coffeehubimg02.blob.core.windows.net/product-images/MochaCoffee.png", "Mocha Blend", 7.89m },
                    { 6, "A bold coffee infused with dark chocolate and fruity raspberry accents for a unique twist.", "https://coffeehubimg02.blob.core.windows.net/product-images/ChocRaspberryCoffee.png", "Chocolate Raspberry", 8.29m },
                    { 7, "A refreshing coffee blend with tangy raw mango notes for an unexpected, vibrant flavor.", "https://coffeehubimg02.blob.core.windows.net/product-images/MangoCoffee.png", "Raw Mango", 7.99m },
                    { 8, "Light coffee with tropical pineapple hints, delivering a bright and refreshing taste.", "https://coffeehubimg02.blob.core.windows.net/product-images/PineappleCoffee.png", "Pineapple Delight", 7.79m },
                    { 9, "Smooth coffee infused with roasted pistachio flavor for a creamy, nut-forward finish.", "https://coffeehubimg02.blob.core.windows.net/product-images/PistachioCoffee.png", "Royal Pistachio", 8.49m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductId",
                table: "OrderItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductId1",
                table: "OrderItems",
                column: "ProductId1");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
