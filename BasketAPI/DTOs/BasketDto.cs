namespace BasketAPI.DTOs
{
    public class BasketDto
    {
        public int CustomerId { get; set; }

        public List<BasketItemDto> Items { get; set; }
    }
}
