using Customer_OrderAPI.Core.Models;

namespace Customer_OrderAPI.Core.Databases.InMemory
{
    public class OrderMemory
    {
        public Dictionary<string, Order> OrderMem { get; set; }

        public OrderMemory()
        {
            OrderMem = new Dictionary<string, Order>();
        }
    }
}
