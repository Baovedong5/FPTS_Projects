
using Customer_OrderAPI.DTOs.OrderItems;

namespace Customer_OrderAPI.DTOs.Orders
{
    public class OrderDto
    {
        public int Id { get; set; }

        public DateTime OrderDate { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public string District { get; set; }

        public string AdditionalAddress { get; set; }

        public int? CustomerId { get; set; }

        public List<OrderItemDto>? OrderItems { get; set; }
    }
}
