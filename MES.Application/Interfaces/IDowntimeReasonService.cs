using MES.Domain.Entities;

namespace MES.Application.Interfaces;

public interface IDowntimeReasonService
{
    Task<IEnumerable<DowntimeReason>> GetAllAsync();
    Task<DowntimeReason?> GetByIdAsync(int id);
    Task<DowntimeReason> CreateAsync(DowntimeReason reason);
    Task UpdateAsync(DowntimeReason reason);
    Task DeleteAsync(int id);
}