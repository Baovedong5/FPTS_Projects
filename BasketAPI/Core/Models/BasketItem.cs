namespace BasketAPI.Core.Models
{
    public class BasketItem
    {
        public int Id { get; set; } 

        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public int Quantity { get; set; }

        public int Status { get; set; }

        public int CustomerBasketId { get; set; }

        public Basket Basket { get; set; }
    }
}
