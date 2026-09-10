using MES.Application.Interfaces;
using MES.Domain.Entities;

namespace MES.Application.Services;

public class DowntimeReasonService : IDowntimeReasonService
{
    private readonly IUnitOfWork _unitOfWork;

    public DowntimeReasonService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<DowntimeReason>> GetAllAsync() => await _unitOfWork.DowntimeReasons.GetAllAsync();

    public async Task<DowntimeReason?> GetByIdAsync(int id) => await _unitOfWork.DowntimeReasons.GetByIdAsync(id);

    public async Task<DowntimeReason> CreateAsync(DowntimeReason reason)
    {
        await _unitOfWork.DowntimeReasons.AddAsync(reason);
        await _unitOfWork.SaveChangesAsync();
        return reason;
    }

    public async Task UpdateAsync(DowntimeReason reason)
    {
        _unitOfWork.DowntimeReasons.Update(reason);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var reason = await _unitOfWork.DowntimeReasons.GetByIdAsync(id);
        if (reason is not null)
        {
            _unitOfWork.DowntimeReasons.Delete(reason);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
