using System;

namespace Embed.Bookshop.Entities
{
    public class Book
    {
        public Guid Id { get; set; }
        public string ISBN { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
    }
}
