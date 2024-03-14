using Customer_OrderAPI.Core.IRepositories;
using Customer_OrderAPI.Core.Repositories;
using Customer_OrderAPI.DTOs.Customers;
using Customer_OrderAPI.DTOs.Orders;
using Customer_OrderAPI.Mappers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Customer_OrderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpGet]
        public async Task<IActionResult> ListOrder()
        {
            var orders = await _orderRepository.GetListAsync();

            var orderDto = orders.Select(o => o.ToOrderDto());
            
            return Ok(orderDto);
        }

        [HttpPost("{customerId}")]
        public async Task<IActionResult> CreateOrder([FromRoute] int customerId,[FromBody] CreateOrderDto createOrderDto)
        {
            var orderModel = createOrderDto.ToOrderFromCreateDto(customerId);

            await _orderRepository.CreateAsync(orderModel);

            return Ok(orderModel.ToOrderDto());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder([FromRoute] int id, [FromBody] UpdateOrderDto updateOrderDto)
        {
            var orderModel = await _orderRepository.UpdateAsync(id, updateOrderDto.ToOrderFromUpdateDto());

            return Ok(orderModel.ToOrderDto());
        }
    }
}
