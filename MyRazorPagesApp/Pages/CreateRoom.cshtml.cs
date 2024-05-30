using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
namespace MyRazorPagesApp.Pages;

public class CreateRoomModel : PageModel
{
    private readonly AppDbContext _context;

    public CreateRoomModel(AppDbContext context)
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
        return RedirectToPage("./Room");
    }
}