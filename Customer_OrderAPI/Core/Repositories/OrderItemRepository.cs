using Customer_OrderAPI.Core.Databases;
using Customer_OrderAPI.Core.Databases.InMemory;
using Customer_OrderAPI.Core.IRepositories;
using Customer_OrderAPI.Core.Models;

namespace Customer_OrderAPI.Core.Repositories
{
    public class OrderItemRepository : IOrderItemRepository
    {
        private readonly ApplicationDbContext _context;

        private readonly OrderItemMemory _inMem;

        private readonly ILogger<OrderItemRepository> _logger;

        public OrderItemRepository(ApplicationDbContext context, OrderItemMemory inMem, ILogger<OrderItemRepository> logger)
        {
            _context = context;
            _inMem = inMem; 
            _logger = logger;
        }

        public async Task<OrderItem> CreateAsync(OrderItem item)
        {
            try
            {
                var orderItem = _inMem.OrderItemMem.FirstOrDefault(o => o.Value.Id == item.Id).Value;

                if (orderItem == null)
                {
                   _inMem.OrderItemMem.Add(item.Id.ToString(), item);

                    await _context.OrderItems.AddAsync(item);

                    await _context.SaveChangesAsync();

                    return item;
                }
                else
                {
                    _logger.LogError("Order Item is already exist");
                    throw new Exception("Order Item is already exist");
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }
        }

        public async Task<List<OrderItem>> GetAllAsync()
        {
            try
            {
                var orderItems = _inMem.OrderItemMem.Values.ToList();

                return orderItems;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }
        }
    }
}
