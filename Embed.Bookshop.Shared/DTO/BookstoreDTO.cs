using Embed.Bookshop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Embed.Bookshop.DTO
{
    public class BookstoreDTO
    {
        public Guid BookstoreId { get; set; }
        public string BookstoreName { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
    }
}
