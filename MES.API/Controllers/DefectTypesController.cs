using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using MES.Application.Interfaces;
using MES.Application.DTOs;
using MES.Domain.Entities;

namespace MES.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DefectTypesController : ControllerBase
{
    private readonly IDefectTypeService _service;
    private readonly IMapper _mapper;

    public DefectTypesController(IDefectTypeService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<DefectTypeDto>>> GetAll()
    {
        var types = await _service.GetAllAsync();
        return Ok(_mapper.Map<IEnumerable<DefectTypeDto>>(types));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<DefectTypeDto>> GetById(int id)
    {
        var type = await _service.GetByIdAsync(id);
        if (type is null) return NotFound();
        return Ok(_mapper.Map<DefectTypeDto>(type));
    }

    [HttpPost]
    public async Task<ActionResult<DefectTypeDto>> Create(CreateDefectTypeDto createDto)
    {
        var type = _mapper.Map<DefectType>(createDto);
        var created = await _service.CreateAsync(type);
        var dto = _mapper.Map<DefectTypeDto>(created);
        return CreatedAtAction(nameof(GetById), new { id = dto.Id }, dto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, CreateDefectTypeDto updateDto)
    {
        var type = await _service.GetByIdAsync(id);
        if (type is null) return NotFound();
        _mapper.Map(updateDto, type);
        await _service.UpdateAsync(type);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteAsync(id);
        return NoContent();
    }
}
