using Microsoft.EntityFrameworkCore;
using MES.Application.Interfaces;
using MES.Application.QueryParameters;
using MES.Domain.Entities;

namespace MES.Infrastructure.Persistence.Repositories;

public class WorkOrderRepository : IWorkOrderRepository
{
    private readonly ApplicationDbContext _context;

    public WorkOrderRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<WorkOrder>> GetFilteredAsync(WorkOrderQueryParameters query)
    {
        var workOrders = _context.WorkOrders
            .Include(w => w.Product)
            .Include(w => w.Machine)
            .Include(w => w.AssignedUser)
            .AsQueryable();

        if (query.Status.HasValue)
            workOrders = workOrders.Where(w => w.Status == query.Status.Value);

        if (query.MachineId.HasValue)
            workOrders = workOrders.Where(w => w.MachineId == query.MachineId.Value);

        if (query.ProductId.HasValue)
            workOrders = workOrders.Where(w => w.ProductId == query.ProductId.Value);

        if (query.FromDate.HasValue)
            workOrders = workOrders.Where(w => w.PlannedStart >= query.FromDate.Value);

        if (query.ToDate.HasValue)
            workOrders = workOrders.Where(w => w.PlannedStart <= query.ToDate.Value);

        return await workOrders.ToListAsync();
    }
}
