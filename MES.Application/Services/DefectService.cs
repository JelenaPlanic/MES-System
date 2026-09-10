using MES.Application.Interfaces;
using MES.Domain.Entities;

namespace MES.Application.Services;

public class DefectService : IDefectService
{
    private readonly IUnitOfWork _unitOfWork;

    public DefectService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Defect>> GetAllAsync()
    {
        return await _unitOfWork.Defects.GetAllAsync(
            d => d.WorkOrder,
            d => d.DefectType);
    }

    public async Task<Defect?> GetByIdAsync(int id)
    {
        return await _unitOfWork.Defects.GetByIdAsync(id,
            d => d.WorkOrder,
            d => d.DefectType);
    }

    public async Task<Defect> CreateAsync(Defect defect)
    {
        await _unitOfWork.Defects.AddAsync(defect);
        await _unitOfWork.SaveChangesAsync();
        return defect;
    }

    public async Task UpdateAsync(Defect defect)
    {
        _unitOfWork.Defects.Update(defect);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var defect = await _unitOfWork.Defects.GetByIdAsync(id);
        if (defect is not null)
        {
            _unitOfWork.Defects.Delete(defect);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
