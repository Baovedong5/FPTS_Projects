using Customer_OrderAPI.Core.Databases.InMemory;
using Microsoft.EntityFrameworkCore;

namespace Customer_OrderAPI.Core.Databases
{
    public class OrderMemorySeedAsync
    {
        public async Task SeedAsync(OrderMemory memory, ApplicationDbContext context)
        {
            var data = await context.Orders.Include(x => x.OrderItems).ToListAsync();
            if (data.Count > 0)
            {
                foreach (var item in data)
                {
                    memory.OrderMem.Add(item.Id.ToString(), item);
                }
            }
        }
    }
}
