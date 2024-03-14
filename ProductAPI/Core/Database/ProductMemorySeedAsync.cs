using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using ProductAPI.Core.Database.InMemory;
using System;

namespace ProductAPI.Core.Database
{
    public class ProductMemorySeedAsync
    {
        public async Task SeedAsync(ProductMemory memory, ApplicationDbContext dbContext)
        {
            var data = await dbContext.Products.ToListAsync();
            if (data.Count > 0)
            {
                foreach (var item in data)
                {
                    memory.ProductMem.Add(item.Id.ToString(), item);
                }
            }
        }
    }
}
