using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using MES.Application.Interfaces;
using MES.Application.DTOs;
using MES.Domain.Entities;

namespace MES.API.Controllers;

[ApiController]
[Route("api/[controller]")]
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
    public async Task<ActionResult<IEnumerable<WorkOrderDto>>> GetAll()
    {
        var workOrders = await _workOrderService.GetAllAsync();
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
    public async Task<IActionResult> Update(int id, CreateWorkOrderDto updateDto)
    {
        var workOrder = await _workOrderService.GetByIdAsync(id);
        if (workOrder is null) return NotFound();

        _mapper.Map(updateDto, workOrder);
        await _workOrderService.UpdateAsync(workOrder);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _workOrderService.DeleteAsync(id);
        return NoContent();
    }
}
