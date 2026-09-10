using MES.Domain.Entities;

namespace MES.Application.Interfaces
{
    public interface IDefectTypeService
    {
        Task<IEnumerable<DefectType>> GetAllAsync();
        Task<DefectType?> GetByIdAsync(int id);
        Task<DefectType> CreateAsync(DefectType defectType);
        Task UpdateAsync(DefectType defectType);
        Task DeleteAsync(int id);
    }
}
