using Lab_ASP.Data;
using Lab_ASP.Models;
using Lab_ASP.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Lab_ASP.Services
{
    public class RentalRepository : IRentalRepository
    {
        private readonly ApplicationDbContext _context;
        public RentalRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Rental>> GetAllAsync()
        {
            return await _context.Rentals.ToListAsync();
        }
        public async Task<Rental?> GetByIdAsync(int id)
        {
            return await _context.Rentals.FindAsync(id);
        }
        public async Task AddAsync(Rental rental)
        {
            _context.Rentals.Add(rental);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Rental rental)
        {
            _context.Rentals.Update(rental);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var rental = await _context.Rentals.FindAsync(id);
            if (rental != null)
            {
                _context.Rentals.Remove(rental);
                await _context.SaveChangesAsync();
            }
        }
    }
}
