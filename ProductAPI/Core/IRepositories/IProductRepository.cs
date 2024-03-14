using ProductAPI.Core.Models;

namespace ProductAPI.Core.IRepositories
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllAsync();

        Task<Product> GetByIdAsync(int id);

        Task<Product> CreateAsync(Product product);

        Task<Product> UpdateAsync(int id, Product product);

        Task<Product> DeleteAsync(int id);
    }
}
