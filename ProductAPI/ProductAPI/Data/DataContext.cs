using Microsoft.EntityFrameworkCore;
using ProductAPI.Entities;
using ProductAPI.SecretHasher;

namespace ProductAPI.Data
{
    public class DataContext(DbContextOptions options) : DbContext(options)
    {
        public required DbSet<Entities.AppUser> Users { get; set; }
        public required DbSet<Entities.Product> Products { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data for Products table
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    ProductName = "Apple AirPods Pro (2nd Generation)",
                    Price = 199.99m,
                    ImageUrl = "https://m.media-amazon.com/images/I/61SUj2aKoEL._AC_SX522_.jpg",
                    ProductUrl = "https://www.amazon.com/dp/B0D1XD1ZV3"
                },
                new Product
                {
                    Id = 2,
                    ProductName = "Sony WH-1000XM5 Noise Cancelling Headphones",
                    Price = 298.00m,
                    ImageUrl = "https://m.media-amazon.com/images/I/51aXvjzcukL.__AC_SX300_SY300_QL70_FMwebp_.jpg",
                    ProductUrl = "https://www.amazon.com/dp/B09XS7JWHH"
                },
                new Product
                {
                    Id = 3,
                    ProductName = "Samsung Galaxy S23 Ultra",
                    Price = 1149.97m,
                    ImageUrl = "https://m.media-amazon.com/images/I/71HtN4qqLZL.__AC_SX300_SY300_QL70_FMwebp_.jpg",
                    ProductUrl = "https://www.amazon.com/dp/B0BLP2Y34S"
                },
                new Product
                {
                    Id = 4,
                    ProductName = "Fitbit Charge 5 Fitness Tracker",
                    Price = 119.95m,
                    ImageUrl = "https://m.media-amazon.com/images/I/61wn2jfhBkL.__AC_SX300_SY300_QL70_FMwebp_.jpg",
                    ProductUrl = "https://www.amazon.com/dp/B0CC63GZ3R"
                },
                new Product
                {
                    Id = 5,
                    ProductName = "Ninja Foodi 9-in-1 Pressure Cooker",
                    Price = 89.99m,
                    ImageUrl = "https://m.media-amazon.com/images/I/71GhytEjuYL.__AC_SX300_SY300_QL70_FMwebp_.jpg",
                    ProductUrl = "https://www.amazon.com/dp/B0CDHP76FP"
                },
                new Product
                {
                    Id = 6,
                    ProductName = "Bose QuietComfort 45 Bluetooth Headphones",
                    Price = 329.00m,
                    ImageUrl = "https://m.media-amazon.com/images/I/61JY8Eci-LL._AC_SX679_.jpg",
                    ProductUrl = "https://www.amazon.com/dp/B0CCZ26B5V"
                },
                new Product
                {
                    Id = 7,
                    ProductName = "Apple MacBook Air M2",
                    Price = 799.00m,
                    ImageUrl = "https://m.media-amazon.com/images/I/719C6bJv8jL._AC_SX522_.jpg",
                    ProductUrl = "https://www.amazon.com/dp/B0DLHCWH55"
                },
                new Product
                {
                    Id = 8,
                    ProductName = "GoPro HERO11 Black Action Camera",
                    Price = 358.49m,
                    ImageUrl = "https://m.media-amazon.com/images/I/81hqcAQdFSL._AC_SX679_.jpg",
                    ProductUrl = "https://www.amazon.com/dp/B087HRMHXY"
                },
                new Product
                {
                    Id = 9,
                    ProductName = "Amazon Echo (4th Gen)",
                    Price = 54.99m,
                    ImageUrl = "https://m.media-amazon.com/images/I/81t8gScXClL._AC_SY300_SX300_.jpg",
                    ProductUrl = "https://www.amazon.com/dp/B07XKF5RM3"
                },
                new Product
                {
                    Id = 10,
                    ProductName = "LG 55-Inch 4K OLED TV",
                    Price = 1396.99m,
                    ImageUrl = "https://m.media-amazon.com/images/I/71O7wgely5L.__AC_SY300_SX300_QL70_FMwebp_.jpg",
                    ProductUrl = "https://www.amazon.com/dp/B0BVXF72HV"
                },
                new Product
                {
                    Id = 11,
                    ProductName = "Sony PlayStation 5 Console",
                    Price = 775.00m,
                    ImageUrl = "https://m.media-amazon.com/images/I/61VTGdjik6L._SX522_.jpg",
                    ProductUrl = "https://www.amazon.com/dp/B0CNV1DTCX"
                }
            );

            modelBuilder.Entity<AppUser>().HasData(
                new AppUser
                {
                    Id = 1,
                    UserName = "robert",
                    PasswordHash = ProtectPassword.Hash("Robert$123"),
                },
                new AppUser
                {
                    Id = 2,
                    UserName = "sonia",
                    PasswordHash = ProtectPassword.Hash("Sonia$123"),

                },
                new AppUser
                {
                    Id = 3,
                    UserName = "ethan",
                    PasswordHash = ProtectPassword.Hash("Ethan$123"),
                },
                new AppUser
                {
                    Id = 4,
                    UserName = "brian",
                    PasswordHash = ProtectPassword.Hash("Brian$123"),
                },
                new AppUser
                {
                    Id = 5,
                    UserName = "samantha",
                    PasswordHash = ProtectPassword.Hash("Samantha$123"),
                }
            );
        }
    }
}

