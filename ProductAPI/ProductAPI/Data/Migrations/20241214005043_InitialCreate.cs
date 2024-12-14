using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProductAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ImageUrl", "Price", "ProductName", "ProductUrl" },
                values: new object[,]
                {
                    { 1, "https://m.media-amazon.com/images/I/41Lg9iTcsDL._AC_SL1000_.jpg", 249.99m, "Apple AirPods Pro (2nd Generation)", "https://www.amazon.com/dp/B0BD7DHHJ4" },
                    { 2, "https://m.media-amazon.com/images/I/91zCwJq2trL._AC_SL1500_.jpg", 348.00m, "Sony WH-1000XM5 Noise Cancelling Headphones", "https://www.amazon.com/dp/B09JZ5LR8M" },
                    { 3, "https://m.media-amazon.com/images/I/91g1MwQswsL._AC_SL1500_.jpg", 1199.99m, "Samsung Galaxy S23 Ultra", "https://www.amazon.com/dp/B0BN4N1NVK" },
                    { 4, "https://m.media-amazon.com/images/I/71hZlxQvf5L._AC_SL1500_.jpg", 129.95m, "Fitbit Charge 5 Fitness Tracker", "https://www.amazon.com/dp/B097R8FRF7" },
                    { 5, "https://m.media-amazon.com/images/I/91g9h2yEn7L._AC_SL1500_.jpg", 199.99m, "Ninja Foodi 9-in-1 Pressure Cooker", "https://www.amazon.com/dp/B08QV5LBHT" },
                    { 6, "https://m.media-amazon.com/images/I/91nK8fXcY9L._AC_SL1500_.jpg", 329.00m, "Bose QuietComfort 45 Bluetooth Headphones", "https://www.amazon.com/dp/B097J2DGG4" },
                    { 7, "https://m.media-amazon.com/images/I/81Po6RSeybL._AC_SL1500_.jpg", 1199.99m, "Apple MacBook Air M2", "https://www.amazon.com/dp/B09Y3M7N6T" },
                    { 8, "https://m.media-amazon.com/images/I/71YkttnQ9FL._AC_SL1500_.jp", 399.00m, "GoPro HERO11 Black Action Camera", "https://www.amazon.com/dp/B09D7SZMFS" },
                    { 9, "https://m.media-amazon.com/images/I/71m0kBejd1L._AC_SL1000_.jpg", 99.99m, "Amazon Echo (4th Gen)", "https://www.amazon.com/dp/B07ZVJGZ9F" },
                    { 10, "https://m.media-amazon.com/images/I/91YvSzYjS6L._AC_SL1500_.jpg", 1496.99m, "LG 55-Inch 4K OLED TV", "https://www.amazon.com/dp/B08GGVFV1H" },
                    { 11, "https://m.media-amazon.com/images/I/71Fj7YQEX6L._AC_SL1500_.jpg", 499.99m, "Sony PlayStation 5 Console", "https://www.amazon.com/dp/B08FC5L3RG" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "UserName" },
                values: new object[,]
                {
                    { 1, "Robert" },
                    { 2, "Sonia" },
                    { 3, "Ethan" },
                    { 4, "Brian" },
                    { 5, "Samantha" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
