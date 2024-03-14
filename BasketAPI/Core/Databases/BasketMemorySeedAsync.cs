using BasketAPI.Core.Databases.InMemory;
using Microsoft.EntityFrameworkCore;

namespace BasketAPI.Core.Databases
{
    public class BasketMemorySeedAsync
    {
        public async Task SeedAsync(BasketMemory memory, ApplicationDbContext context)
        {
            var baskets = await context.Baskets.Include(b => b.Items).ToListAsync();
            if(baskets.Count > 0 )
            {
                foreach( var item in baskets )
                {
                    memory.BasketMem.Add(item.CustomerId.ToString(), item);
                }
            }
        }
    }
}
