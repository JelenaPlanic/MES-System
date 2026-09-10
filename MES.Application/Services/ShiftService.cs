using MES.Application.Interfaces;
using MES.Domain.Entities;

namespace MES.Application.Services;

public class ShiftService : IShiftService
{
    private readonly IUnitOfWork _unitOfWork;

    public ShiftService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Shift>> GetAllAsync() => await _unitOfWork.Shifts.GetAllAsync();

    public async Task<Shift?> GetByIdAsync(int id) => await _unitOfWork.Shifts.GetByIdAsync(id);

    public async Task<Shift> CreateAsync(Shift shift)
    {
        await _unitOfWork.Shifts.AddAsync(shift);
        await _unitOfWork.SaveChangesAsync();
        return shift;
    }

    public async Task UpdateAsync(Shift shift)
    {
        _unitOfWork.Shifts.Update(shift);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var shift = await _unitOfWork.Shifts.GetByIdAsync(id);
        if (shift is not null)
        {
            _unitOfWork.Shifts.Delete(shift);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
