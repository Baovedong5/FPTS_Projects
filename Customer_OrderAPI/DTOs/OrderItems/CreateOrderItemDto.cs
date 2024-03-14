namespace Customer_OrderAPI.DTOs.OrderItems
{
    public class CreateOrderItemDto
    {
        public int Id { get; set; }

        public string ProductName { get; set; }

        public string ProductId { get; set; }

        public int Quantity { get; set; }

        public int OrderId { get; set; }
    }
}
