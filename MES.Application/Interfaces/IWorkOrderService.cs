using MES.Application.DTOs;
using MES.Domain.Entities;

namespace MES.Application.Interfaces;

public interface IWorkOrderService
{
    Task<IEnumerable<WorkOrder>> GetAllAsync();
    Task<WorkOrder?> GetByIdAsync(int id);
    Task<WorkOrder> CreateAsync(WorkOrder workOrder);
    Task UpdateAsync(WorkOrder workOrder);
    Task DeleteAsync(int id);

    Task<OeeResultDto> CalculateOeeAsync(int workOrderId);
}