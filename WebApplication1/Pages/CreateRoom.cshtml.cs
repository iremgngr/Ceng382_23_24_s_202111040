using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Data;
using WebApplication1.Models;

namespace MyApp.Namespace
{
    public class CreateRoomModel : PageModel
    {
        private readonly ApplicationDbContext _context;

    public CreateRoomModel(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Room? Room { get; set; }

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }
        if(Room != null){
        _context.Rooms.Add(Room);
        await _context.SaveChangesAsync();
        }
        return RedirectToPage("./Rooms");
    }
    }
}
