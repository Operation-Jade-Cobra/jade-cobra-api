using System.Collections.Generic;
using System.Linq;
using jade.cobra.Domain.Catalog;

namespace jade.cobra.Domain.Orders
{
        public class OrderItem
    {
        public int Id { get; set; }
        public Item Item { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
    
    public class Order
    {
        public int Id { get; set; }
        public List<OrderItem> Items { get; set; }
        public DateTime CreatedDate { get; set; }
        public decimal Total => Items.Sum(i => i.Price);
    }


}