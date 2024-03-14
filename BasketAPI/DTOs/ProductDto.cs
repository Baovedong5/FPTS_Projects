namespace BasketAPI.DTOs
{
    public class ProductDto
    {
        public int id {  get; set; }

        public string name { get; set; }

        public decimal price { get; set; }

        public int availableQuantity { get; set; }
    }
}
