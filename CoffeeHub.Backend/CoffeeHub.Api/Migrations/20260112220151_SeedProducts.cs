using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CoffeeHub.Api.Migrations
{
    /// <inheritdoc />
    public partial class SeedProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "Products",
                newName: "Image");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Image", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "A rich and bold espresso made from premium Arabica beans, perfect for strong coffee lovers.", "espresso.png", "Classic Espresso", 6.99m },
                    { 2, "Smooth coffee infused with warm hazelnut notes for a nutty and comforting flavor.\",\r\n  },", "hazelnut.png", "Hazelnut Coffee", 7.49m },
                    { 3, "A balanced coffee blend with subtle vanilla sweetness for a smooth, aromatic cup.", "vanilla.png", "Vanilla Brew", 7.29m },
                    { 4, "Medium-roasted coffee with buttery caramel undertones and a naturally sweet finish.", "caramel.png", "Caramel Roast", 7.59m },
                    { 5, "A deep coffee blend combined with chocolate notes for a rich and indulgent taste.", "mocha.png", "Mocha Blend", 7.89m },
                    { 6, "A bold coffee infused with dark chocolate and fruity raspberry accents for a unique twist.", "chocoRaspberry.png", "Chocolate Raspberry", 8.29m },
                    { 7, "A refreshing coffee blend with tangy raw mango notes for an unexpected, vibrant flavor.", "mango.png", "Raw Mango", 7.99m },
                    { 8, "Light coffee with tropical pineapple hints, delivering a bright and refreshing taste.", "pineapple.png", "Pineapple Delight", 7.79m },
                    { 9, "Smooth coffee infused with roasted pistachio flavor for a creamy, nut-forward finish.", "pistachio.png", "Royal Pistachio", 8.49m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.RenameColumn(
                name: "Image",
                table: "Products",
                newName: "ImageUrl");
        }
    }
}
