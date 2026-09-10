using AutoMapper;
using MES.Application.DTOs;
using MES.Application.Interfaces;
using MES.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MES.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductServise _productService;
        private readonly IMapper _mapper;

        public ProductsController(IProductServise productServise, IMapper mapper)
        {
            _productService = productServise;
            _mapper = mapper;
        }

        [HttpGet] // mapira se na GET /api/products
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetAll()
        {
            var products = await _productService.GetAllAsync();
            var dtos = _mapper.Map<IEnumerable<ProductDto>>(products);
            return Ok(dtos);
        }

        [HttpGet("{id}")] // mapira se na GET /api/products/5 iz URl, AUTOM SE POVEZE SA PAR
        public async Task<ActionResult<ProductDto>> GetById(int id) 
        {
           var product = await _productService.GetByIdAsync(id);
            if(product is null)
            {
                return NotFound();
            }

            var dto = _mapper.Map<ProductDto>(product);
            return Ok(dto);
        }

        [HttpPost] // mapira se na POST /api/products
        public async Task<ActionResult<ProductDto>> Create(CreateProductDto createDto)
        {
            var product = _mapper.Map<Product>(createDto);
            var created = await _productService.CreateAsync(product);
            var dto = _mapper.Map<ProductDto>(created);

            return CreatedAtAction(nameof(GetById), new { id = dto.Id }, dto); // 201 i link ka novom resursu
        }

        [HttpPut("{id}")] // mapira se na GET /api/products/5 iz URl, AUTOM SE POVEZE SA PAR
        public async Task<IActionResult>Update(int id, CreateProductDto updateDto)
        {
            var product = await _productService.GetByIdAsync(id);
            if (product is null)
            {
                return NotFound();
            }

            _mapper.Map(updateDto, product); // azurira postojeci, ne pravi novi object
            await _productService.UpdateAsync(product);

            return NoContent(); // 204
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _productService.DeleteAsync(id);
            return NoContent();
        }
    }
}
