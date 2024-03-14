using Customer_OrderAPI.Core.Models;
using Customer_OrderAPI.DTOs.OrderItems;
using Customer_OrderAPI.DTOs.Orders;

namespace Customer_OrderAPI.Mappers
{
    public static class OrderMapper
    {
        public static OrderDto ToOrderDto (this Order order)
        {
            return new OrderDto
            {
                Id = order.Id,
                OrderDate = order.OrderDate,
                Street = order.Street,
                City = order.City,
                District = order.District,
                AdditionalAddress = order.AdditionalAddress,
                CustomerId = order.CustomerId,
                OrderItems = order.OrderItems?.Select(x => x.ToOrderItemDto()).ToList() ?? new List<OrderItemDto>(),
            };
        }

        public static Order ToOrderFromCreateDto (this CreateOrderDto createOrderDto, int CustomerId)
        {
            return new Order
            {
                Id = createOrderDto.Id,
                OrderDate = createOrderDto.OrderDate,
                Street = createOrderDto.Street,
                City = createOrderDto.City,
                District = createOrderDto.District,
                AdditionalAddress = createOrderDto.AdditionalAddress,
                CustomerId = CustomerId
            };
        }

        public static Order ToOrderFromUpdateDto (this UpdateOrderDto updateOrderDto)
        {
            return new Order
            {
                OrderDate = updateOrderDto.OrderDate,
                Street = updateOrderDto.Street,
                City = updateOrderDto.City,
                District = updateOrderDto.District,
                AdditionalAddress = updateOrderDto.AdditionalAddress,
            };
        }
    }
}
