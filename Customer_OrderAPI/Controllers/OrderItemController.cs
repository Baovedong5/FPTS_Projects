using Customer_OrderAPI.Core.IRepositories;
using Customer_OrderAPI.DTOs.OrderItems;
using Customer_OrderAPI.Mappers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Customer_OrderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemController : ControllerBase
    {
        private readonly IOrderItemRepository _orderItemRepository;

        public OrderItemController(IOrderItemRepository orderItemRepository)
        {
            _orderItemRepository = orderItemRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetListOrderItem()
        {
            var orderItems = await _orderItemRepository.GetAllAsync();

            var orderItemDto = orderItems.Select(x => x.ToOrderItemDto());

            return Ok(orderItemDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrderItem([FromBody] CreateOrderItemDto createOrderItemDto)
        {
            var orderItemModel = await _orderItemRepository.CreateAsync(createOrderItemDto.ToOrderItemFromCreate());

            return Ok(orderItemModel);
        }
    }
}
