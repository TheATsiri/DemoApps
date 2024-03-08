using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorMessageWallApp.Pages
{
    public class MessageWallModel : PageModel
    {
        [BindProperty]
        public string Message { get; set; }
        public List<string> Messages { get; set; } = new();
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            Messages.Add(Message);
            return Page();
        }
    }
}
