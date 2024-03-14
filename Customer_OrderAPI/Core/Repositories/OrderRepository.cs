using Customer_OrderAPI.Core.Databases;
using Customer_OrderAPI.Core.Databases.InMemory;
using Customer_OrderAPI.Core.IRepositories;
using Customer_OrderAPI.Core.Models;
using Microsoft.Extensions.Logging;

namespace Customer_OrderAPI.Core.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderMemory _inMem;

        private readonly ApplicationDbContext _context;

        private readonly ILogger<OrderRepository> _logger;

        public OrderRepository(OrderMemory inMem, ApplicationDbContext context, ILogger<OrderRepository> logger)
        {
            _context = context;
            _inMem = inMem; 
            _logger = logger;
        }

        public async Task<Order> CreateAsync(Order order)
        {
            try
            {
                var orderExisting = _inMem.OrderMem.FirstOrDefault(o => o.Value.Id == order.Id).Value;

                if(orderExisting == null)
                {
                    _inMem.OrderMem.Add(order.Id.ToString(), order);

                    await _context.Orders.AddAsync(order);

                    await _context.SaveChangesAsync();

                    return order;
                }
                else
                {
                    _logger.LogError("Product is already exist");
                    throw new Exception("Product is already exist");
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }
        }

        public async Task<List<Order>> GetListAsync()
        {
            try
            {
                var orders = _inMem.OrderMem.Values.ToList();

                return orders;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }
        }

        public async Task<Order> UpdateAsync(int id, Order order)
        {
            try
            {
                var orderExisting = _inMem.OrderMem.FirstOrDefault(o => o.Value.Id == id).Value;

                if (orderExisting != null)
                {
                    orderExisting.OrderDate = order.OrderDate;
                    orderExisting.Street = order.Street;
                    orderExisting.City = order.City;
                    orderExisting.District = order.District;
                    orderExisting.AdditionalAddress = order.AdditionalAddress;

                    _context.Orders.Update(orderExisting);

                    await _context.SaveChangesAsync();

                    return orderExisting;
                }
                else
                {
                    _logger.LogError("Product is not exist");
                    throw new Exception("Product is not exist");
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }
        }
    }
}
