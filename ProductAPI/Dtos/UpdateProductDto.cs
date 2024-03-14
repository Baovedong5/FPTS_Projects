namespace ProductAPI.Dtos
{
    public class UpdateProductDto
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public int AvailableQuantity { get; set; }
    }
}
