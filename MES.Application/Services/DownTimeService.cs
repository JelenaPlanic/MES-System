using MES.Application.Interfaces;
using MES.Domain.Entities;

namespace MES.Application.Services;

public class DowntimeService : IDowntimeService
{
    private readonly IUnitOfWork _unitOfWork;

    public DowntimeService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Downtime>> GetAllAsync() // eager loading - 2FK
    {
        return await _unitOfWork.Downtimes.GetAllAsync(
            d => d.WorkOrder,
            d => d.DowntimeReason);
    }

    public async Task<Downtime?> GetByIdAsync(int id) // eager loading
    {
        return await _unitOfWork.Downtimes.GetByIdAsync(id,
            d => d.WorkOrder,
            d => d.DowntimeReason);
    }

    public async Task<Downtime> CreateAsync(Downtime downtime)
    {
        await _unitOfWork.Downtimes.AddAsync(downtime);
        await _unitOfWork.SaveChangesAsync();
        return downtime;
    }

    public async Task UpdateAsync(Downtime downtime)
    {
        _unitOfWork.Downtimes.Update(downtime);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var downtime = await _unitOfWork.Downtimes.GetByIdAsync(id);
        if (downtime is not null)
        {
            _unitOfWork.Downtimes.Delete(downtime);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
