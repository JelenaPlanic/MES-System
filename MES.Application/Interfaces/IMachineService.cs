
using MES.Domain.Entities;

namespace MES.Application.Interfaces
{
    public interface IMachineService
    {
        Task<IEnumerable<Machine>> GetAllAsync();
        Task<Machine?> GetByIdAsync(int id);
        Task<Machine> CreateAsync(Machine machine);
        Task UpdateAsync(Machine machine);
        Task DeleteAsync(int id);
    }
}
