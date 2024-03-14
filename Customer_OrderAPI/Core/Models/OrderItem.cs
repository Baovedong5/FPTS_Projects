namespace Customer_OrderAPI.Core.Models
{
    public class OrderItem
    {
        public int Id { get; set; }

        public string ProductName { get; set; }

        public string ProductId { get; set; }

        public int Quantity { get; set; }

        public int OrderId { get; set; }

        public Order? Order { get; set; }
    }
}
