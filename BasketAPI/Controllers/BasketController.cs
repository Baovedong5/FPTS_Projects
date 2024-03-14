using BasketAPI.Core.IRepositories;
using BasketAPI.Mappers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BasketAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketRepository _basketRepository;

        public BasketController(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBasket()
        {
            var baskets = await _basketRepository.ListAsync();

            var basketsDto = baskets.Select(c => c.ToBasketDto());

            return Ok(basketsDto);
        }
    }
}
