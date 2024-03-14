using Customer_OrderAPI.Core.Databases.InMemory;
using Microsoft.EntityFrameworkCore;

namespace Customer_OrderAPI.Core.Databases
{
    public class CustomerMemorySeedAsync
    {
        public async Task SeedAsync(CustomerMemory memory, ApplicationDbContext context)
        {
            var data = await context.Customers.Include(c => c.Orders).ThenInclude(c => c.OrderItems).ToListAsync();
            if(data.Count > 0)
            {
                foreach (var item in data)
                {
                    memory.CustomerMem.Add(item.Id.ToString(), item);
                }
            }
        }
    }
}
