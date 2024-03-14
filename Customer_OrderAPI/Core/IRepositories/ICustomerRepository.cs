using Customer_OrderAPI.Core.Models;

namespace Customer_OrderAPI.Core.IRepositories
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> ListAsync();

        Task<Customer> GetByIdAsync(int id);

        Task<Customer> CreateAsync(Customer customer);

        Task<Customer> UpdateAsync(int id ,Customer customer);

        Task<Customer> DeleteAsnc(int id);
    }
}
