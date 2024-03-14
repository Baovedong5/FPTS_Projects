using BasketAPI.Core.Models;

namespace BasketAPI.Core.IRepositories
{
    public interface IBasketItemRepository
    {
        Task<BasketItem> CreateAsync(BasketItem item);
    }
}
