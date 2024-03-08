using System.ComponentModel.DataAnnotations;

namespace BlazozServerMessageWallApp.Models;

public class MessageModel
{
    [Required]
    [StringLength(10, MinimumLength = 5)]
    public string? Message { get; set; }
}
