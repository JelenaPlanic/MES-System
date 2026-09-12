using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using MES.Application.Interfaces;
using MES.Application.DTOs;
using MES.Domain.Entities;
using MES.Application.QueryParameters;
using Microsoft.AspNetCore.Authorization;

namespace MES.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class WorkOrdersController : ControllerBase
{
    private readonly IWorkOrderService _workOrderService;
    private readonly IMapper _mapper;

    public WorkOrdersController(IWorkOrderService workOrderService, IMapper mapper)
    {
        _workOrderService = workOrderService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<WorkOrderDto>>> GetAll([FromQuery] WorkOrderQueryParameters query)
    {
        var workOrders = await _workOrderService.GetFilteredAsync(query);
        return Ok(_mapper.Map<IEnumerable<WorkOrderDto>>(workOrders));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<WorkOrderDto>> GetById(int id)
    {
        var workOrder = await _workOrderService.GetByIdAsync(id);
        if (workOrder is null) return NotFound();
        return Ok(_mapper.Map<WorkOrderDto>(workOrder));
    }

    [HttpPost]
    public async Task<ActionResult<WorkOrderDto>> Create(CreateWorkOrderDto createDto)
    {
        var workOrder = _mapper.Map<WorkOrder>(createDto);
        workOrder.Status = WorkOrderStatus.Planned; // nalog uvek krece kao sto je planiran

        var created = await _workOrderService.CreateAsync(workOrder);

        // ucitaj ponovo sa navigacijama, da DTO ima ProductName/MachineName popunjene
        var withIncludes = await _workOrderService.GetByIdAsync(created.Id);
        var dto = _mapper.Map<WorkOrderDto>(withIncludes);

        return CreatedAtAction(nameof(GetById), new { id = dto.Id }, dto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateWorkOrderDto updateDto)
    {
        var workOrder = await _workOrderService.GetByIdAsync(id);
        if (workOrder is null) return NotFound();

        workOrder.Status = updateDto.Status;
        workOrder.ProducedQuantity = updateDto.ProducedQuantity;
        workOrder.ActualStart = updateDto.ActualStart;
        workOrder.ActualEnd= updateDto.ActualEnd;

        await _workOrderService.UpdateAsync(workOrder);

        return NoContent();
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Manager, Admin")]
    public async Task<IActionResult> Delete(int id)
    {
        await _workOrderService.DeleteAsync(id);
        return NoContent();
    }

    [HttpGet("{id}/oee")] // mapira na GET /api/workorders/5/oee 
    public async Task<ActionResult<OeeResultDto>> GetOee(int id)
    {
        var result = await _workOrderService.CalculateOeeAsync(id);

        return Ok(result);
    }
}
