using BasketAPI.Core.Models;
using BasketAPI.DTOs;

namespace BasketAPI.Mappers
{
    public static class BasketItemMapper
    {
        public static BasketItemDto ToBasketItemDto (this BasketItem item)
        {
            return new BasketItemDto
            {
                Id = item.Id,
                ProductId = item.ProductId,
                Quantity = item.Quantity,
                Status = item.Status,
                ProductName = item.ProductName,
                CustomerBasketId = item.CustomerBasketId,
            };
        }

        public static BasketItem ToBasketItemFromCreateDto(this CreateBasketItemDto item)
        {
            return new BasketItem
            {
                Id = item.Id,
                Quantity = item.Quantity,
                ProductId = item.ProductId,
                CustomerBasketId = item.CustomerBasketId,
            };
        }
    }
}
