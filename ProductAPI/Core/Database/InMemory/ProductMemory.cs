using ProductAPI.Core.Models;

namespace ProductAPI.Core.Database.InMemory
{
    public class ProductMemory
    {
        public Dictionary<string, Product> ProductMem { get; set; }

        public ProductMemory()
        {
            ProductMem = new Dictionary<string, Product>();
        }
    }
}
