using BasketAPI.Core.Databases;
using BasketAPI.Core.Databases.InMemory;
using BasketAPI.Core.IRepositories;
using BasketAPI.Core.Models;
using BasketAPI.DTOs;
using System.Text.Json;

namespace BasketAPI.Core.Repositories
{
    public class BasketItemRepository : IBasketItemRepository
    {
        private readonly BasketItemMemory _inMem;

        private readonly ApplicationDbContext _context;

        public BasketItemRepository(BasketItemMemory inMem, ApplicationDbContext context)
        {
            _context = context;
            _inMem = inMem;
        }

        public async Task<BasketItem> CreateAsync(BasketItem item)
        {
            Basket basket = new Basket();

            basket.CustomerId = item.CustomerBasketId;

            await _context.Baskets.AddAsync(basket);

            await _context.SaveChangesAsync();

            using var client = new HttpClient();

            string apiUrl = $"https://localhost:7072/api/v1/product/{item.ProductId}";

            try
            {
               HttpResponseMessage response = await client.GetAsync(apiUrl);

               if(response.IsSuccessStatusCode)
               {
                    string content = await response.Content.ReadAsStringAsync();

                    ProductDto products = JsonSerializer.Deserialize<ProductDto>(content);

                    BasketItem basketItem = new BasketItem();

                    basketItem.Id = item.Id;
                    basketItem.ProductName = products.name;
                    basketItem.ProductId = item.ProductId;
                    basketItem.Status = 1;
                    basketItem.Quantity = item.Quantity;
                    basketItem.CustomerBasketId = item.CustomerBasketId;

                    await _context.BasketItems.AddAsync(basketItem);

                    await _context.SaveChangesAsync();

                    return basketItem;
               }
               else
               {
                    return null;
               }
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
