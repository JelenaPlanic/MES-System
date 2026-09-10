using MES.Domain.Entities;

namespace MES.Application.Interfaces;

public interface IDowntimeService
{
    Task<IEnumerable<Downtime>> GetAllAsync();
    Task<Downtime?> GetByIdAsync(int id);
    Task<Downtime> CreateAsync(Downtime downtime);
    Task UpdateAsync(Downtime downtime);
    Task DeleteAsync(int id);
}
