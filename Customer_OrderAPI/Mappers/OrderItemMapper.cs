using Customer_OrderAPI.Core.Models;
using Customer_OrderAPI.DTOs.OrderItems;

namespace Customer_OrderAPI.Mappers
{
    public static class OrderItemMapper
    {
        public static OrderItemDto ToOrderItemDto (this OrderItem item)
        {
            return new OrderItemDto
            {
                Id = item.Id,
                OrderId = item.OrderId,
                ProductId = item.ProductId,
                ProductName = item.ProductName,
                Quantity = item.Quantity,
            };
        }

        public static OrderItem ToOrderItemFromCreate (this CreateOrderItemDto createOrderItemDto)
        {
            return new OrderItem
            {
                Id = createOrderItemDto.Id,
                OrderId = createOrderItemDto.OrderId,
                ProductId = createOrderItemDto.ProductId,
                Quantity = createOrderItemDto.Quantity,
                ProductName = createOrderItemDto.ProductName,
            };
        }
    }
}
