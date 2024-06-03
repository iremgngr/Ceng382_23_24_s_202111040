using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Models;

namespace MyApp.Namespace // Bu namespace'i doğru şekilde ayarladığınızdan emin olun
{
    public class ReservationsListModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public ReservationsListModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Reservation> Reservations { get; set; }

        public async Task OnGetAsync()
        {
            Reservations = await _context.Reservations
                .Include(r => r.Room) // Oda bilgilerini de dahil etmek için Include kullanıyoruz
                .ToListAsync();
        }
    }
}