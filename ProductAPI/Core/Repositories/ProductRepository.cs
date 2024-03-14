using Oracle.ManagedDataAccess.Client;
using ProductAPI.Core.Database;
using ProductAPI.Core.Database.InMemory;
using ProductAPI.Core.IRepositories;
using ProductAPI.Core.Models;
using System.Data;

namespace ProductAPI.Core.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IConfiguration _configuration;

        private readonly ILogger<ProductRepository> _logger;

        private readonly ApplicationDbContext _context;

        private readonly ProductMemory _inMem;

        public ProductRepository(IConfiguration configuration, ILogger<ProductRepository> logger, ApplicationDbContext context , ProductMemory inMem)
        {
            _configuration = configuration;
            _logger = logger;
            _context = context;
            _inMem = inMem;
        }

        public async Task<Product> CreateAsync(Product product)
        {
            using (OracleConnection connection = new OracleConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();

                using (OracleCommand command = new OracleCommand("sp_InsertProduct", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("p_Id", OracleDbType.Int32).Value = product.Id;
                    command.Parameters.Add("p_Name", OracleDbType.Varchar2).Value = product.Name;
                    command.Parameters.Add("p_Price", OracleDbType.Decimal).Value = product.Price;
                    command.Parameters.Add("p_AvailableQuantity", OracleDbType.Int32).Value = product.AvailableQuantity;

                    try
                    {
                        command.ExecuteNonQuery();
                        _inMem.ProductMem.Add(product.Id.ToString(), product);
                    }
                    catch (Exception e)
                    {
                        _logger.LogError(e.Message);
                        throw;
                    }
                }
            }
            return product;
        }

        public async Task<Product> DeleteAsync(int id)
        {
            using (OracleConnection connection = new OracleConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();

                using (OracleCommand command = new OracleCommand("sp_DeleteProduct", connection ))
                {
                    command.CommandType= CommandType.StoredProcedure;
                    command.Parameters.Add("p_id",OracleDbType.Int32).Value = id;

                    try
                    {
                        command.ExecuteNonQuery ();

                        if (_inMem.ProductMem.TryGetValue(id.ToString(), out Product exstingProduct))
                        {
                            _inMem.ProductMem.Remove(id.ToString());

                            return exstingProduct;
                        }
                        else
                        {
                            throw new Exception("Product is not exist");
                        }
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
            }
        }

        public async Task<List<Product>> GetAllAsync()
        {
            //List<Product> products = new List<Product>();

            //using (OracleConnection connection = new OracleConnection(_configuration.GetConnectionString("DefaultConnection")))
            //{
            //    connection.Open();

            //    using (OracleCommand command = new OracleCommand())
            //    {
            //        try
            //        {
            //            command.CommandText = "sp_GetAll";
            //            command.CommandType = CommandType.StoredProcedure;

            //            OracleParameter p = command.Parameters.Add("p", OracleDbType.RefCursor);
            //            p.Direction = ParameterDirection.Output;

            //            using (OracleDataReader reader = command.ExecuteReader())
            //            {
            //                while (reader.Read())
            //                {
            //                    Map the data to your Product object
            //                   Product product = new Product
            //                   {
            //                       Id = Convert.ToInt32(reader["Id"]),
            //                       Name = reader["Name"].ToString(),
            //                       Price = Convert.ToDecimal(reader["Price"]),
            //                       AvailableQuantity = Convert.ToInt32(reader["AvailableQuantity"])
            //                   };
            //                    products.Add(product);
            //                }
            //            }
            //        }
            //        catch (Exception e)
            //        {
            //            _logger.LogError(e.Message);
            //            throw;
            //        }
            //    }
            //}
             return _inMem.ProductMem.Values.ToList();

         
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            var product = _inMem.ProductMem.FirstOrDefault(p => p.Value.Id == id).Value;

            if(product == null)
            {
                throw new Exception("Product is not exist");
            }

            return product;
        }

        public async Task<Product> UpdateAsync(int id, Product product)
        {
            try
            {
                var exsistingProduct = _inMem.ProductMem.FirstOrDefault(p => p.Value.Id == id).Value;

                if(exsistingProduct != null)
                {
                    using (OracleConnection connection = new OracleConnection(_configuration.GetConnectionString("DefaultConnection")))
                    {
                        connection.Open();

                        using (OracleCommand command = new OracleCommand("sp_UpdateProduct", connection))
                        {
                            command.CommandType = CommandType.StoredProcedure;

                            command.Parameters.Add("p_Id", OracleDbType.Int32).Value = id;
                            command.Parameters.Add("p_Name", OracleDbType.NVarchar2).Value = product.Name;
                            command.Parameters.Add("p_Price", OracleDbType.Decimal).Value = product.Price;
                            command.Parameters.Add("p_AvailableQuantity", OracleDbType.Int32 ).Value = product.AvailableQuantity;

                            try
                            {
                                command.ExecuteNonQuery();

                                exsistingProduct.Price = product.Price;
                                exsistingProduct.AvailableQuantity = product.AvailableQuantity;
                                exsistingProduct.Name = product.Name;


                                return exsistingProduct;
                            }
                            catch (Exception e)
                            {
                                _logger.LogError(e.Message);
                                throw;
                            }
                        }
                    }
                }
                else
                {
                    throw new Exception("Product is not exist");
                }
               
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
