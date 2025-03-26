using Lab_ASP.Models;

namespace Lab_ASP.Repositories
{
    public interface IEquipmentTypeRepository
    {
        Task<IEnumerable<EquipmentType>> GetAllAsync();
        Task<EquipmentType?> GetByIdAsync(int id);
        Task AddAsync(EquipmentType equipmetType);
        Task UpdateAsync(EquipmentType equipmentType);
        Task DeleteAsync(int id);
    }
}
