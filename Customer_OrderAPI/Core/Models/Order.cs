namespace Customer_OrderAPI.Core.Models
{
    public class Order
    {
        public int Id { get; set; }

        public DateTime OrderDate { get; set; }

        public int CustomerId { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public string District { get; set; }

        public string AdditionalAddress { get; set; }

        public List<OrderItem> OrderItems { get; set; }

        public Customer? Customer {  get; set; }  
    }
}
