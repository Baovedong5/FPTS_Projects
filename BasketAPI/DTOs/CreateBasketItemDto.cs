namespace BasketAPI.DTOs
{
    public class CreateBasketItemDto
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int CustomerBasketId { get; set; }

        public int Quantity { get; set; }
    }
}
