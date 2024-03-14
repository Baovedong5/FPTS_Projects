using BasketAPI.Core.Databases.InMemory;
using Microsoft.EntityFrameworkCore;

namespace BasketAPI.Core.Databases
{
    public class BasketItemMemorySeedAsync
    {
        public async Task SeedAsync(BasketItemMemory memory, ApplicationDbContext context)
        {
            var basketItems = await context.BasketItems.ToListAsync();

            if(basketItems.Count > 0)
            {
                foreach(var item in basketItems)
                {
                    memory.BasketItemMem.Add(item.Id.ToString(), item);
                }
            }
        }
    }
}
