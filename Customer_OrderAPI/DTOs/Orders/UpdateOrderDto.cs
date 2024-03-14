namespace Customer_OrderAPI.DTOs.Orders
{
    public class UpdateOrderDto
    {
        public DateTime OrderDate { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public string District { get; set; }

        public string AdditionalAddress { get; set; }
    }
}
