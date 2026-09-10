using MES.Application.Interfaces;
using MES.Domain.Entities;

namespace MES.Application.Services;

public class WorkOrderService : IWorkOrderService
{
    private readonly IUnitOfWork _unitOfWork;

    public WorkOrderService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<WorkOrder>> GetAllAsync()
    {
        return await _unitOfWork.WorkOrders.GetAllAsync(
            w => w.Product, // JOIN
            w => w.Machine,
            w => w.AssignedUser);
    }

    public async Task<WorkOrder?> GetByIdAsync(int id)
    {
        return await _unitOfWork.WorkOrders.GetByIdAsync(id,
            w => w.Product,
            w => w.Machine,
            w => w.AssignedUser);
    }

    public async Task<WorkOrder> CreateAsync(WorkOrder workOrder)
    {
        await _unitOfWork.WorkOrders.AddAsync(workOrder);
        await _unitOfWork.SaveChangesAsync();
        return workOrder;
    }

    public async Task UpdateAsync(WorkOrder workOrder)
    {
        _unitOfWork.WorkOrders.Update(workOrder);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var workOrder = await _unitOfWork.WorkOrders.GetByIdAsync(id);
        if (workOrder is not null)
        {
            _unitOfWork.WorkOrders.Delete(workOrder);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
