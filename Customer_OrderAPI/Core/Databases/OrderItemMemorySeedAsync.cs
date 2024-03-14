using Customer_OrderAPI.Core.Databases.InMemory;
using Microsoft.EntityFrameworkCore;

namespace Customer_OrderAPI.Core.Databases
{
    public class OrderItemMemorySeedAsync
    {
        public async Task SeedAsync(OrderItemMemory memory, ApplicationDbContext context)
        {
            var data = await context.OrderItems.ToListAsync();
            if (data.Count > 0)
            {
                foreach (var item in data)
                {
                    memory.OrderItemMem.Add(item.Id.ToString(), item);
                }
            }
        }
    }
}
