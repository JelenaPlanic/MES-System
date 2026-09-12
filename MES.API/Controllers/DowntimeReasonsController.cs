using AutoMapper;
using MES.Application.DTOs;
using MES.Application.Interfaces;
using MES.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MES.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class DowntimeReasonsController : ControllerBase
{
    private readonly IDowntimeReasonService _service;
    private readonly IMapper _mapper;

    public DowntimeReasonsController(IDowntimeReasonService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<DowntimeReasonDto>>> GetAll()
    {
        var reasons = await _service.GetAllAsync();
        return Ok(_mapper.Map<IEnumerable<DowntimeReasonDto>>(reasons));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<DowntimeReasonDto>> GetById(int id)
    {
        var reason = await _service.GetByIdAsync(id);
        if (reason is null) return NotFound();
        return Ok(_mapper.Map<DowntimeReasonDto>(reason));
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<DowntimeReasonDto>> Create(CreateDowntimeReasonDto createDto)
    {
        var reason = _mapper.Map<DowntimeReason>(createDto);
        var created = await _service.CreateAsync(reason);
        var dto = _mapper.Map<DowntimeReasonDto>(created);
        return CreatedAtAction(nameof(GetById), new { id = dto.Id }, dto);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Update(int id, CreateDowntimeReasonDto updateDto)
    {
        var reason = await _service.GetByIdAsync(id);
        if (reason is null) return NotFound();
        _mapper.Map(updateDto, reason);
        await _service.UpdateAsync(reason);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteAsync(id);
        return NoContent();
    }
}
