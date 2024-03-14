namespace BasketAPI.DTOs
{
    public class BasketItemDto
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public int Quantity { get; set; }

        public int Status { get; set; }

        public int CustomerBasketId { get; set; }
    }
}
