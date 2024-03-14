using BasketAPI.Core.IRepositories;
using BasketAPI.DTOs;
using BasketAPI.Mappers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BasketAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketItemController : ControllerBase
    {
        private readonly IBasketItemRepository _basketItemRepository;

        public BasketItemController(IBasketItemRepository basketItemRepository)
        {
            _basketItemRepository = basketItemRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBasketItem([FromBody] CreateBasketItemDto createBasketItemDto)
        {
            var basketModel = createBasketItemDto.ToBasketItemFromCreateDto();

            var dto = await _basketItemRepository.CreateAsync(basketModel);

            return Ok(dto.ToBasketItemDto());
        }
    }
}
