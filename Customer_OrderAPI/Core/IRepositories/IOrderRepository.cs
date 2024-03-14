using Customer_OrderAPI.Core.Models;

namespace Customer_OrderAPI.Core.IRepositories
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetListAsync();

        Task<Order> CreateAsync(Order order);

        Task<Order> UpdateAsync(int id, Order order);
    }
}
