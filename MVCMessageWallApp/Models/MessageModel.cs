using System.ComponentModel.DataAnnotations;

namespace MVCMessageWallApp.Models
{
    public class MessageModel
    {
        [Required]
        public string Message { get; set; }
    }
}
