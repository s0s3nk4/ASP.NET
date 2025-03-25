﻿using Lab_ASP.Models;

namespace Lab_ASP.Services
{
    public interface IEquipmentRepository
    {
        Task<IEnumerable<Equipment>> GetAllAsync();
        Task<Equipment?> GetByIdAsync(int id);
        Task AddAsync(Equipment equipment);
        Task UpdateAsync(Equipment equipment);
        Task DeleteAsync(int id);
    }
}
