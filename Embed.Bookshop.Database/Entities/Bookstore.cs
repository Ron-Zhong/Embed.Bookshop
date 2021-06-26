using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Embed.Bookshop.Entities
{
    public class Bookstore
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public List<Inventory> Inventories { get; set; }
    }
}
