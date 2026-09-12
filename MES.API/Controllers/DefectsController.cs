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
public class DefectsController : ControllerBase
{
    private readonly IDefectService _service;
    private readonly IMapper _mapper;

    public DefectsController(IDefectService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<DefectDto>>> GetAll()
    {
        var defects = await _service.GetAllAsync();
        return Ok(_mapper.Map<IEnumerable<DefectDto>>(defects));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<DefectDto>> GetById(int id)
    {
        var defect = await _service.GetByIdAsync(id);
        if (defect is null) return NotFound();
        return Ok(_mapper.Map<DefectDto>(defect));
    }

    [HttpPost]
    public async Task<ActionResult<DefectDto>> Create(CreateDefectDto createDto)
    {
        var defect = _mapper.Map<Defect>(createDto);
        var created = await _service.CreateAsync(defect);

        var withIncludes = await _service.GetByIdAsync(created.Id);
        var dto = _mapper.Map<DefectDto>(withIncludes);

        return CreatedAtAction(nameof(GetById), new { id = dto.Id }, dto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, CreateDefectDto updateDto)
    {
        var defect = await _service.GetByIdAsync(id);
        if (defect is null) return NotFound();

        _mapper.Map(updateDto, defect);
        await _service.UpdateAsync(defect);

        return NoContent();
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Manager, Admin")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteAsync(id);
        return NoContent();
    }
}
