using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyRazorPagesApp.Pages;

public class RoomModel : PageModel
{
    private readonly AppDbContext _context;

    public RoomModel(AppDbContext context)
    {
        _context = context;
    }

    public IList<Room> Rooms { get; set; }

    public async Task OnGetAsync()
    {
        Rooms = await _context.Rooms.ToListAsync();
    }
}