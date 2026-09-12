using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using MES.Application.Interfaces;
using MES.Application.DTOs;
using MES.Domain.Entities;
using Microsoft.AspNetCore.Authorization;

namespace MES.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class MachinesController : ControllerBase
{
    private readonly IMachineService _machineService;
    private readonly IMapper _mapper;

    public MachinesController(IMachineService machineService, IMapper mapper)
    {
        _machineService = machineService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<MachineDto>>> GetAll()
    {
        var machines = await _machineService.GetAllAsync();
        return Ok(_mapper.Map<IEnumerable<MachineDto>>(machines));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<MachineDto>> GetById(int id)
    {
        var machine = await _machineService.GetByIdAsync(id);
        if (machine is null) return NotFound();
        return Ok(_mapper.Map<MachineDto>(machine));
    }

    [HttpPost]
    [Authorize(Roles = "Manager, Admin")]
    public async Task<ActionResult<MachineDto>> Create(CreateMachineDto createDto)
    {
        var machine = _mapper.Map<Machine>(createDto);
        var created = await _machineService.CreateAsync(machine);
        var dto = _mapper.Map<MachineDto>(created);
        return CreatedAtAction(nameof(GetById), new { id = dto.Id }, dto);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Manager, Admin")]
    public async Task<IActionResult> Update(int id, CreateMachineDto updateDto)
    {
        var machine = await _machineService.GetByIdAsync(id);
        if (machine is null) return NotFound();
        _mapper.Map(updateDto, machine);
        await _machineService.UpdateAsync(machine);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Manager, Admin")]
    public async Task<IActionResult> Delete(int id)
    {
        await _machineService.DeleteAsync(id);
        return NoContent();
    }
}