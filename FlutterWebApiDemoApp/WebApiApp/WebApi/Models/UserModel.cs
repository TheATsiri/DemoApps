using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class UserModel
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        public string? Name { get; set; } = "";
        [Required]
        public string? Address { get; set; } = "";
    }
}
