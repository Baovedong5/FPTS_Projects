using BasketAPI.Core.Models;

namespace BasketAPI.Core.IRepositories
{
    public interface IBasketRepository
    {
        Task<List<Basket>> ListAsync();
    }
}
