using System.ComponentModel.DataAnnotations;

namespace ProductAPI.DTOs
{
    public class LoginDto
    {
        [MaxLength(100)]
        public required string Username { get; set; }
        public required string Password { get; set; }
    }
}
