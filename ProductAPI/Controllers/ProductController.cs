using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductAPI.Core.IRepositories;
using ProductAPI.Core.Models;
using ProductAPI.Dtos;
using ProductAPI.Mappers;

namespace ProductAPI.Controllers
{
    [Route("api/v1/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductRepository _productRepo;

        public ProductController(IProductRepository productRepo)
        {
            _productRepo = productRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var product = await _productRepo.GetAllAsync();

            var proudctDto = product.Select(p => p.ToProductDto());

            return Ok(product);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var product = await _productRepo.GetByIdAsync(id);

            return Ok(product.ToProductDto());
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductDto createDto)
        {
            var product = createDto.ToProductFromCreateDto();

            await _productRepo.CreateAsync(product);

            return CreatedAtAction(nameof(GetById), new {id = product.Id}, product.ToProductDto());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct([FromRoute] int id, [FromBody] UpdateProductDto updateDto)
        {
            var productModel = updateDto.ToProductFromUpdateDto();

            var product = await _productRepo.UpdateAsync(id, productModel);

            return Ok(product.ToProductDto());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] int id)
        {
            await _productRepo.DeleteAsync(id);

            return NoContent();
        }
    }
}
