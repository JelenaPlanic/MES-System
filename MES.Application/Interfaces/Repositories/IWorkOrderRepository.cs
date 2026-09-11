using MES.Domain.Entities;
using MES.Application.QueryParameters;

namespace MES.Application.Interfaces;

public interface IWorkOrderRepository
{
    Task<IEnumerable<WorkOrder>> GetFilteredAsync(WorkOrderQueryParameters query);
}
