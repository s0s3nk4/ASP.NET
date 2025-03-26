using Lab_ASP.Models;

namespace Lab_ASP.Repositories
{
    public interface IRentalPointRepository
    {
        Task<IEnumerable<RentalPoint>> GetRentalPoints();
        Task<RentalPoint> GetByIdAsync(int id);
        Task AddAsync(RentalPoint rentalPoint);
        Task UpdateAsync(RentalPoint rentalPoint);
        Task DeleteAsync(int id);
    }
}
