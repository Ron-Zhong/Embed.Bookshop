using System;
using System.ComponentModel.DataAnnotations;

namespace Embed.Bookshop.Entities
{
    public class Order
    {
        [Key]
        public Guid Id { get; set; }
        
        public string Customer { get; set; }

        public Guid InventoryId { get; set; }
        public Inventory Inventory { get; set; }

        public int Amount { get; set; }
        public double Price { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
