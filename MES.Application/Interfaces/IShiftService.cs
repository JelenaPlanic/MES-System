using MES.Domain.Entities;

namespace MES.Application.Interfaces;

public interface IShiftService
{
    Task<IEnumerable<Shift>> GetAllAsync();
    Task<Shift?> GetByIdAsync(int id);
    Task<Shift> CreateAsync(Shift shift);
    Task UpdateAsync(Shift shift);
    Task DeleteAsync(int id);
}
