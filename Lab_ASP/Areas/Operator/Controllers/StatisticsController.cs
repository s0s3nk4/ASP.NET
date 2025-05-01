using Lab_ASP.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab_ASP.Areas.Operator.Controllers
{
    [Authorize(Roles = "Operator, Admin")]
    [Area("Operator")]
    public class StatisticsController : Controller
    {
        private readonly ApplicationDbContext _context;
        public StatisticsController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var totalRentals = await _context.Rentals.CountAsync();

            var totalRevenue = await _context.Rentals
                .Where(r => r.Price.HasValue)
                .SumAsync(r => r.Price.Value);

            var rentalPerUser = await _context.Rentals
                .GroupBy(r => r.UserId)
                .Select(g => new
                {
                    UserId = g.Key,
                    RentalCount = g.Count(),
                    Total = g.Sum(r => r.Price ?? 0)
                })
                .ToListAsync();

            ViewBag.TotalRentals = totalRentals;
            ViewBag.TotalRevenue = totalRevenue;
            ViewBag.RentalPerUser = rentalPerUser;
            return View();
        }
    }
}
