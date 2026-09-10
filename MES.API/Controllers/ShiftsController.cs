using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using MES.Application.Interfaces;
using MES.Application.DTOs;
using MES.Domain.Entities;

namespace MES.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ShiftsController : ControllerBase
{
    private readonly IShiftService _service;
    private readonly IMapper _mapper;

    public ShiftsController(IShiftService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ShiftDto>>> GetAll()
    {
        var shifts = await _service.GetAllAsync();
        return Ok(_mapper.Map<IEnumerable<ShiftDto>>(shifts));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ShiftDto>> GetById(int id)
    {
        var shift = await _service.GetByIdAsync(id);
        if (shift is null) return NotFound();
        return Ok(_mapper.Map<ShiftDto>(shift));
    }

    [HttpPost]
    public async Task<ActionResult<ShiftDto>> Create(CreateShiftDto createDto)
    {
        var shift = _mapper.Map<Shift>(createDto);
        var created = await _service.CreateAsync(shift);
        var dto = _mapper.Map<ShiftDto>(created);
        return CreatedAtAction(nameof(GetById), new { id = dto.Id }, dto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, CreateShiftDto updateDto)
    {
        var shift = await _service.GetByIdAsync(id);
        if (shift is null) return NotFound();
        _mapper.Map(updateDto, shift);
        await _service.UpdateAsync(shift);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteAsync(id);
        return NoContent();
    }
}