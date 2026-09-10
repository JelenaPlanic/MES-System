using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using MES.Application.Interfaces;
using MES.Application.DTOs;
using MES.Domain.Entities;

namespace MES.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DowntimesController : ControllerBase
{
    private readonly IDowntimeService _service;
    private readonly IMapper _mapper;

    public DowntimesController(IDowntimeService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<DowntimeDto>>> GetAll()
    {
        var downtimes = await _service.GetAllAsync();
        return Ok(_mapper.Map<IEnumerable<DowntimeDto>>(downtimes));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<DowntimeDto>> GetById(int id)
    {
        var downtime = await _service.GetByIdAsync(id);
        if (downtime is null) return NotFound();
        return Ok(_mapper.Map<DowntimeDto>(downtime));
    }

    [HttpPost]
    public async Task<ActionResult<DowntimeDto>> Create(CreateDowntimeDto createDto)
    {
        var downtime = _mapper.Map<Downtime>(createDto);
        var created = await _service.CreateAsync(downtime);

        var withIncludes = await _service.GetByIdAsync(created.Id);
        var dto = _mapper.Map<DowntimeDto>(withIncludes);

        return CreatedAtAction(nameof(GetById), new { id = dto.Id }, dto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, CreateDowntimeDto updateDto)
    {
        var downtime = await _service.GetByIdAsync(id);
        if (downtime is null) return NotFound();

        _mapper.Map(updateDto, downtime);
        await _service.UpdateAsync(downtime);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteAsync(id);
        return NoContent();
    }
}
