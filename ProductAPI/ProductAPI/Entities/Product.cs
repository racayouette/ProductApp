using System.ComponentModel.DataAnnotations;

namespace ProductAPI.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public required string ProductName { get; set; }
        public decimal Price { get; set; }
        public required string ImageUrl { get; set; }
        public required string ProductUrl { get; set; }

    }
}