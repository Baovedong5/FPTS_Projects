namespace ProductAPI.Dtos
{
    public class CreateProductDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int AvailableQuantity { get; set; }
    }
}
