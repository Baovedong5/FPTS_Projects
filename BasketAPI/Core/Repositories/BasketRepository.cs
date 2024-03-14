using BasketAPI.Core.Databases.InMemory;
using BasketAPI.Core.IRepositories;
using BasketAPI.Core.Models;

namespace BasketAPI.Core.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        private readonly BasketMemory _inMem;

        public BasketRepository(BasketMemory inMem)
        {
            _inMem = inMem; 
        }

        public Task<List<Basket>> ListAsync()
        {
            var baskets = _inMem.BasketMem.Values.ToList();

            return Task.FromResult(baskets);
        }
    }
}
