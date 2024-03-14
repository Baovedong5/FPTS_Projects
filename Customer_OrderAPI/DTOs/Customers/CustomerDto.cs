using Customer_OrderAPI.Core.Models;
using Customer_OrderAPI.DTOs.Orders;

namespace Customer_OrderAPI.DTOs.Customers
{
    public class CustomerDto
    {
        public int Id { get; set; }

        public string PhoneNumber { get; set; }

        public string Name { get; set; }

        public List<OrderDto> Orders { get; set; }
    }
}
