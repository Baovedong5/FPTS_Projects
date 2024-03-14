using Customer_OrderAPI.Core.Databases;
using Customer_OrderAPI.Core.Databases.InMemory;
using Customer_OrderAPI.Core.IRepositories;
using Customer_OrderAPI.Core.Models;

namespace Customer_OrderAPI.Core.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerMemory _inMem;

        private readonly ILogger<CustomerRepository> _logger;

        private readonly ApplicationDbContext _context;

        public CustomerRepository(CustomerMemory inMem, ILogger<CustomerRepository> logger, ApplicationDbContext context)
        {
            _inMem = inMem;
            _logger = logger;
            _context = context;
        }

        public async Task<Customer> CreateAsync(Customer customer)
        {
            try
            {
                var customerExisting =  _inMem.CustomerMem.FirstOrDefault(x => x.Value.Id == customer.Id).Value;

                if(customerExisting == null)
                { 
                    _inMem.CustomerMem.Add(customer.Id.ToString(), customer);

                    await _context.Customers.AddAsync(customer);

                    await _context.SaveChangesAsync();

                    return customer;
                }
                else
                {
                    _logger.LogError("Customer is already exist");
                    throw new Exception("Customer is already exist");
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }
        }

        public async Task<Customer> DeleteAsnc(int id)
        {
            try
            {
                var customerExsisting = await GetByIdAsync(id);
                if( customerExsisting == null)
                {
                    _logger.LogError($"Customer {id} exsisting");
                    throw new Exception($"Customer {id} exsisting");
                }
                else
                {
                    _inMem.CustomerMem.Remove(id.ToString());

                    _context.Customers.Remove(customerExsisting);

                    await _context.SaveChangesAsync();

                    return customerExsisting;
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }
        }

        public async Task<Customer> GetByIdAsync(int id)
        {
            try
            {
                var customer = _inMem.CustomerMem.FirstOrDefault(x => x.Value.Id == id).Value;

                if(customer == null)
                {
                    _logger.LogError($"Customer {id} is not exist");
                    throw new Exception($"Customer {id} is not exist");
                }
                else
                {
                    return customer;
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }
        }

        public async Task<List<Customer>> ListAsync()
        {
            try
            {
                var customers = _inMem.CustomerMem.Values.ToList();

                return customers;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }
        }

        public async Task<Customer> UpdateAsync(int id, Customer customer)
        {
            try
            {
                var customerExsisting = _inMem.CustomerMem.FirstOrDefault(x => x.Value.Id == id).Value;

                if(customerExsisting == null)
                {
                    _logger.LogError("Customer is not exist");
                    throw new Exception("Customer is not exist");
                }
                else
                {
                    customerExsisting.Name = customer.Name;
                    customerExsisting.PhoneNumber = customer.PhoneNumber;

                    _context.Customers.Update(customerExsisting);
                    
                    await _context.SaveChangesAsync();
                    
                    return customerExsisting;
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }
        }
    }
}
