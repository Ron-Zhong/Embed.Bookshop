using System;
using System.ComponentModel.DataAnnotations;

namespace Embed.Bookshop.Entities
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
    }
}
