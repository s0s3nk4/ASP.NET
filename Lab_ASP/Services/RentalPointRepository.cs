using Lab_ASP.Data;
using Lab_ASP.Models;
using Lab_ASP.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Lab_ASP.Services
{
    public class RentalPointRepository : IRentalPointRepository
    {
        private readonly ApplicationDbContext _context;
        public RentalPointRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<RentalPoint>> GetRentalPoints()
        {
            return await _context.RentalPoints.ToListAsync();
        }
        public async Task<RentalPoint?> GetByIdAsync(int id)
        {
            return await _context.RentalPoints.FindAsync(id);
        }
        public async Task AddAsync(RentalPoint rentalPoint)
        {
            _context.RentalPoints.Add(rentalPoint);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(RentalPoint rentalPoint)
        {
            _context.RentalPoints.Update(rentalPoint);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var rentalPoint = await _context.RentalPoints.FindAsync(id);
            if (rentalPoint != null)
            {
                _context.RentalPoints.Remove(rentalPoint);
                await _context.SaveChangesAsync();
            }
        }
    }
}
