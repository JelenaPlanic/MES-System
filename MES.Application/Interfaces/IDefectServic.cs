using MES.Domain.Entities;

namespace MES.Application.Interfaces;

public interface IDefectService
{
    Task<IEnumerable<Defect>> GetAllAsync();
    Task<Defect?> GetByIdAsync(int id);
    Task<Defect> CreateAsync(Defect defect);
    Task UpdateAsync(Defect defect);
    Task DeleteAsync(int id);
}
