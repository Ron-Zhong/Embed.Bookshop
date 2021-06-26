using Embed.Bookshop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Embed.Bookshop.DTO
{
    public class BookDTO
    {
        public string ISBN { get; set; }
        public string BookName { get; set; }
        public string Author { get; set; }

        public int Stocks { get; set; }
        public double MinPrice { get; set; }
        public double MaxPrice { get; set; }

        public List<BookstoreDTO> Bookstores { get; set; }
    }
}
