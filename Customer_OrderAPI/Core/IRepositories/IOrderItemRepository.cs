using Customer_OrderAPI.Core.Models;

namespace Customer_OrderAPI.Core.IRepositories
{
    public interface IOrderItemRepository
    {
        Task<List<OrderItem>> GetAllAsync();

        Task<OrderItem> CreateAsync(OrderItem item);
    }
}
