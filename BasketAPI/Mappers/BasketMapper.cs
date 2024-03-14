using BasketAPI.Core.Models;
using BasketAPI.DTOs;

namespace BasketAPI.Mappers
{
    public static class BasketMapper
    {
        public static BasketDto ToBasketDto(this Basket basket)
        {
            return new BasketDto
            {
                CustomerId = basket.CustomerId,
                Items = basket.Items.Select(x => x.ToBasketItemDto()).ToList(),
            };
        }
    }
}
