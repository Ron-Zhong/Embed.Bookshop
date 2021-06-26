using System;
using System.ComponentModel.DataAnnotations;

namespace Embed.Bookshop.Entities
{
    public class Inventory
    {
        [Key]
        public Guid Id { get; set; }

        public Guid BookstoreId { get; set; }
        public Bookstore Bookstore { get; set; }

        public string ISBN { get; set; }
        public string Author { get; set; }
        public string BookName { get; set; }

        public int Stock { get; set; }
        public double Price { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
