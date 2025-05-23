﻿using Lab_ASP.Models;

namespace Lab_ASP.Repositories
{
    public interface IEquipmentRepository
    {
        Task<IEnumerable<Equipment>> GetAllAsync();
        Task<Equipment?> GetByIdAsync(int id);
        Task AddAsync(Equipment equipmet);
        Task UpdateAsync(Equipment equipment);
        Task DeleteAsync(int id);
    }
}
