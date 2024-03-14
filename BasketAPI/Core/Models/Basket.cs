namespace BasketAPI.Core.Models
{
    public class Basket
    {
        public int CustomerId { get; set; }

        public List<BasketItem> Items { get; set; }
    }
}
