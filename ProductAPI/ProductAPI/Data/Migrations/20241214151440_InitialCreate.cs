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
                    { 1, "https://m.media-amazon.com/images/I/61SUj2aKoEL._AC_SX522_.jpg", 199.99m, "Apple AirPods Pro (2nd Generation)", "https://www.amazon.com/dp/B0D1XD1ZV3" },
                    { 2, "https://m.media-amazon.com/images/I/51aXvjzcukL.__AC_SX300_SY300_QL70_FMwebp_.jpg", 298.00m, "Sony WH-1000XM5 Noise Cancelling Headphones", "https://www.amazon.com/dp/B09XS7JWHH" },
                    { 3, "https://m.media-amazon.com/images/I/71HtN4qqLZL.__AC_SX300_SY300_QL70_FMwebp_.jpg", 1149.97m, "Samsung Galaxy S23 Ultra", "https://www.amazon.com/dp/B0BLP2Y34S" },
                    { 4, "https://m.media-amazon.com/images/I/61wn2jfhBkL.__AC_SX300_SY300_QL70_FMwebp_.jpg", 119.95m, "Fitbit Charge 5 Fitness Tracker", "https://www.amazon.com/dp/B0CC63GZ3R" },
                    { 5, "https://m.media-amazon.com/images/I/71GhytEjuYL.__AC_SX300_SY300_QL70_FMwebp_.jpg", 89.99m, "Ninja Foodi 9-in-1 Pressure Cooker", "https://www.amazon.com/dp/B0CDHP76FP" },
                    { 6, "https://m.media-amazon.com/images/I/61JY8Eci-LL._AC_SX679_.jpg", 329.00m, "Bose QuietComfort 45 Bluetooth Headphones", "https://www.amazon.com/dp/B0CCZ26B5V" },
                    { 7, "https://m.media-amazon.com/images/I/719C6bJv8jL._AC_SX522_.jpg", 799.00m, "Apple MacBook Air M2", "https://www.amazon.com/dp/B0DLHCWH55" },
                    { 8, "https://m.media-amazon.com/images/I/81hqcAQdFSL._AC_SX679_.jpg", 358.49m, "GoPro HERO11 Black Action Camera", "https://www.amazon.com/dp/B087HRMHXY" },
                    { 9, "https://m.media-amazon.com/images/I/81t8gScXClL._AC_SY300_SX300_.jpg", 54.99m, "Amazon Echo (4th Gen)", "https://www.amazon.com/dp/B07XKF5RM3" },
                    { 10, "https://m.media-amazon.com/images/I/71O7wgely5L.__AC_SY300_SX300_QL70_FMwebp_.jpg", 1396.99m, "LG 55-Inch 4K OLED TV", "https://www.amazon.com/dp/B0BVXF72HV" },
                    { 11, "https://m.media-amazon.com/images/I/61VTGdjik6L._SX522_.jpg", 775.00m, "Sony PlayStation 5 Console", "https://www.amazon.com/dp/B0CNV1DTCX" }
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
