using MES.Application.Interfaces;
using MES.Domain.Entities;


namespace MES.Application.Services 
{
    public class MachineService : IMachineService
    {
        private readonly IUnitOfWork _unitOfWork;

        public MachineService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Machine>> GetAllAsync() => await _unitOfWork.Machines.GetAllAsync();
        public async Task<Machine?> GetByIdAsync(int id) => await _unitOfWork.Machines.GetByIdAsync(id);
        public async Task<Machine> CreateAsync(Machine machine)
        {
            await _unitOfWork.Machines.AddAsync(machine);
            await _unitOfWork.SaveChangesAsync();
            return machine;
        }
        public async Task UpdateAsync(Machine machine)
        {
            _unitOfWork.Machines.Update(machine);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var machine = await _unitOfWork.Machines.GetByIdAsync(id);
            if (machine is not null)
            {
                _unitOfWork.Machines.Delete(machine);
                await _unitOfWork.SaveChangesAsync();
            }
        }


    }
}
