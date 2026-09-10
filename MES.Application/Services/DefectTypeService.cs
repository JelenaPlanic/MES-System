using MES.Application.Interfaces;
using MES.Domain.Entities;


namespace MES.Application.Services
{
    public class DefectTypeService : IDefectTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        public DefectTypeService(IUnitOfWork unitOfWork)
        {
           _unitOfWork = unitOfWork; 
        }

        public async Task<IEnumerable<DefectType>> GetAllAsync()
        {
            return await _unitOfWork.DefectTypes.GetAllAsync();
        }

        public async Task<DefectType?> GetByIdAsync(int id)
        {
            return await _unitOfWork.DefectTypes.GetByIdAsync(id);
        }

        public async Task<DefectType> CreateAsync(DefectType defectType)
        {
            await _unitOfWork.DefectTypes.AddAsync(defectType);
            await _unitOfWork.SaveChangesAsync();
            return defectType;
        }

        public async Task UpdateAsync(DefectType defectType)
        {
            _unitOfWork.DefectTypes.Update(defectType);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var defectType = await _unitOfWork.DefectTypes.GetByIdAsync(id);
            if(defectType is not null)
            {
                _unitOfWork.DefectTypes.Delete(defectType);
                await _unitOfWork.SaveChangesAsync();
            }
            
        }
    }
}
