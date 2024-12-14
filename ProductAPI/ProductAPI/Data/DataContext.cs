using Microsoft.EntityFrameworkCore;
using ProductAPI.Entities;

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
                    Price = 249.99m,
                    ImageUrl = "https://m.media-amazon.com/images/I/41Lg9iTcsDL._AC_SL1000_.jpg",
                    ProductUrl = "https://www.amazon.com/dp/B0BD7DHHJ4"
                },
                new Product
                {
                    Id = 2,
                    ProductName = "Sony WH-1000XM5 Noise Cancelling Headphones",
                    Price = 348.00m,
                    ImageUrl = "https://m.media-amazon.com/images/I/91zCwJq2trL._AC_SL1500_.jpg",
                    ProductUrl = "https://www.amazon.com/dp/B09JZ5LR8M"
                },
                new Product
                {
                    Id = 3,
                    ProductName = "Samsung Galaxy S23 Ultra",
                    Price = 1199.99m,
                    ImageUrl = "https://m.media-amazon.com/images/I/91g1MwQswsL._AC_SL1500_.jpg",
                    ProductUrl = "https://www.amazon.com/dp/B0BN4N1NVK"
                },
                new Product
                {
                    Id = 4,
                    ProductName = "Fitbit Charge 5 Fitness Tracker",
                    Price = 129.95m,
                    ImageUrl = "https://m.media-amazon.com/images/I/71hZlxQvf5L._AC_SL1500_.jpg",
                    ProductUrl = "https://www.amazon.com/dp/B097R8FRF7"
                },
                new Product
                {
                    Id = 5,
                    ProductName = "Ninja Foodi 9-in-1 Pressure Cooker",
                    Price = 199.99m,
                    ImageUrl = "https://m.media-amazon.com/images/I/91g9h2yEn7L._AC_SL1500_.jpg",
                    ProductUrl = "https://www.amazon.com/dp/B08QV5LBHT"
                },
                new Product
                {
                    Id = 6,
                    ProductName = "Bose QuietComfort 45 Bluetooth Headphones",
                    Price = 329.00m,
                    ImageUrl = "https://m.media-amazon.com/images/I/91nK8fXcY9L._AC_SL1500_.jpg",
                    ProductUrl = "https://www.amazon.com/dp/B097J2DGG4"
                },
                new Product
                {
                    Id = 7,
                    ProductName = "Apple MacBook Air M2",
                    Price = 1199.99m,
                    ImageUrl = "https://m.media-amazon.com/images/I/81Po6RSeybL._AC_SL1500_.jpg",
                    ProductUrl = "https://www.amazon.com/dp/B09Y3M7N6T"
                },
                new Product
                {
                    Id = 8,
                    ProductName = "GoPro HERO11 Black Action Camera",
                    Price = 399.00m,
                    ImageUrl = "https://m.media-amazon.com/images/I/71YkttnQ9FL._AC_SL1500_.jp",
                    ProductUrl = "https://www.amazon.com/dp/B09D7SZMFS"
                },
                new Product
                {
                    Id = 9,
                    ProductName = "Amazon Echo (4th Gen)",
                    Price = 99.99m,
                    ImageUrl = "https://m.media-amazon.com/images/I/71m0kBejd1L._AC_SL1000_.jpg",
                    ProductUrl = "https://www.amazon.com/dp/B07ZVJGZ9F"
                },
                new Product
                {
                    Id = 10,
                    ProductName = "LG 55-Inch 4K OLED TV",
                    Price = 1496.99m,
                    ImageUrl = "https://m.media-amazon.com/images/I/91YvSzYjS6L._AC_SL1500_.jpg",
                    ProductUrl = "https://www.amazon.com/dp/B08GGVFV1H"
                },
                new Product
                {
                    Id = 11,
                    ProductName = "Sony PlayStation 5 Console",
                    Price = 499.99m,
                    ImageUrl = "https://m.media-amazon.com/images/I/71Fj7YQEX6L._AC_SL1500_.jpg",
                    ProductUrl = "https://www.amazon.com/dp/B08FC5L3RG"
                }
            );

            modelBuilder.Entity<AppUser>().HasData(
                new AppUser
                {
                    Id = 1,
                    UserName = "Robert"
                },
                new AppUser
                {
                    Id = 2,
                    UserName = "Sonia"
                },
                new AppUser
                {
                    Id = 3,
                    UserName = "Ethan"
                },
                new AppUser
                {
                    Id = 4,
                    UserName = "Brian"
                },
                new AppUser
                {
                    Id = 5,
                    UserName = "Samantha"
                }
            );
        }
    }


}
