using Customer_OrderAPI.Core.Models;

namespace Customer_OrderAPI.Core.Databases.InMemory
{
    public class OrderItemMemory
    {
        public Dictionary<string, OrderItem> OrderItemMem { get; set; }

        public OrderItemMemory()
        {
            OrderItemMem = new Dictionary<string, OrderItem>();
        }
    }
}
