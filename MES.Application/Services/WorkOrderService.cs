using MES.Application.DTOs;
using MES.Application.Exceptions;
using MES.Application.Interfaces;
using MES.Application.QueryParameters;
using MES.Domain.Entities;
using System.Net;

namespace MES.Application.Services { 

public class WorkOrderService : IWorkOrderService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IWorkOrderRepository _workOrderRepository;

        public WorkOrderService(IUnitOfWork unitOfWork, IWorkOrderRepository repo)
    {
        _unitOfWork = unitOfWork;
        _workOrderRepository = repo;
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

    public async Task<OeeResultDto> CalculateOeeAsync(int workOrderId)
    {
        var workOrder = await _unitOfWork.WorkOrders.GetByIdAsync(workOrderId,
            w => w.DownTimes,
            w => w.Defects,
            w => w.Product);

        if (workOrder is null || workOrder.Status != WorkOrderStatus.Completed)
            throw new NotFoundException($"Radni nalog sa Id {workOrderId} ne postoji");

        if (workOrder.Status != WorkOrderStatus.Completed)
            throw new ValidationException("OEE se moze izracunati samo za zavrsene radne naloge.");

        if (workOrder.ActualStart is null || workOrder.ActualEnd is null)
            throw new ValidationException("Radni nalog nema uneto stvarno vreme pocetka odnosno kraja.");

        var plannedMinutes = (workOrder.ActualEnd.Value - workOrder.ActualStart.Value).TotalMinutes;
        var downtimeMinutes = workOrder.DownTimes  // samo zastoji koji imaju kraj
            .Where(d => d.EndTime is not null)
            .Sum(d => (d.EndTime!.Value - d.StartTime).TotalMinutes); // sabira njihova trajanja

        var availability = OeeCalculationService.CalculateAvailability(plannedMinutes, downtimeMinutes);

        var runTimeMinutes = plannedMinutes - downtimeMinutes;
        var performance = OeeCalculationService.CalculatePerformance(
            workOrder.ProducedQuantity, workOrder.Product.CycleTimeSeconds, runTimeMinutes);

        var defectQuantity = workOrder.Defects.Sum(d => d.Quanity); // kolicina izmeni
        var quality = OeeCalculationService.CalculateQuality(workOrder.ProducedQuantity, defectQuantity);

        var oee = OeeCalculationService.CalculateOee(availability, performance, quality);

        return new OeeResultDto
        {
            WorkOrderId = workOrder.Id,
            OrderNumber = workOrder.OrderNumber,
            Availability = availability,
            Performance = performance,
            Quality = quality,
            Oee = oee
        };
    }

        // filter:
    public async Task<IEnumerable<WorkOrder>> GetFilteredAsync(WorkOrderQueryParameters query)
    {
         return await _workOrderRepository.GetFilteredAsync(query); 
        
    }
}
}
