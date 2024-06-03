using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace MyApp.Namespace
{
    public class CreateReservationModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<CreateReservationModel> _logger;

        public CreateReservationModel(ApplicationDbContext context, UserManager<IdentityUser> userManager, ILogger<CreateReservationModel> logger)
        {
            _context = context;
            _userManager = userManager;
            _logger = logger;
        }

        [BindProperty]
        public Reservation Reservation { get; set; }

        public SelectList Rooms { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            Rooms = new SelectList(await _context.Rooms.ToListAsync(), "Id", "RoomName");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                // Hataları göstermek için bir mesaj ekleyin
                ModelState.AddModelError(string.Empty, "Reservation form has errors. Please check your inputs.");
                Rooms = new SelectList(await _context.Rooms.ToListAsync(), "Id", "RoomName");
                return Page();
            }

            var user = await _userManager.GetUserAsync(User);
            Reservation.ReserverName = user.UserName;

            _context.Reservations.Add(Reservation);
            await _context.SaveChangesAsync();

            _logger.LogInformation("Reservation created by {User} for room {Room} from {Start} to {End}",
                user.UserName, Reservation.RoomId, Reservation.StartTime, Reservation.EndTime);

            return RedirectToPage("./Rooms");
        }
    }
}
