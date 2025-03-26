using Lab_ASP.Data;
using Lab_ASP.Models;
using Lab_ASP.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Lab_ASP.Services
{
    public class EquipmentTypeRepository : IEquipmentTypeRepository
    {
        private readonly ApplicationDbContext _context;
        public EquipmentTypeRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<EquipmentType>> GetAllAsync()
        {
            return await _context.EquipmentTypes.ToListAsync();
        }
        public async Task<EquipmentType?> GetByIdAsync(int id)
        {
            return await _context.EquipmentTypes.FindAsync(id);
        }
        public async Task AddAsync(EquipmentType equipmentType)
        {
            _context.EquipmentTypes.Add(equipmentType);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(EquipmentType equipmentType)
        {
            _context.EquipmentTypes.Update(equipmentType);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var equipmentType = await _context.EquipmentTypes.FindAsync(id);
            if (equipmentType != null)
            {
                _context.EquipmentTypes.Remove(equipmentType);
                await _context.SaveChangesAsync();
            }
        }
    }
}
