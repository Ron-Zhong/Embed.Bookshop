using Embed.Bookshop.DTO;
using Embed.Bookshop.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Embed.Bookshop.Repos
{
    public interface IOrderRepo
    {
        Task<int> CreateAsync(string isbn, Guid bookstoreId, string email);
    }

    public class OrderRepo : IOrderRepo
    {
        public OrderRepo(DBContext context)
        {
            Context = context;
        }

        DBContext Context { get; }

        public async Task<int> CreateAsync(string isbn, Guid bookstoreId, string email)
        {
            //1. Validate
            var inventory = await Context.Inventories
                .Where(x => x.ISBN.Equals(isbn))
                .Where(x => x.BookstoreId.Equals(bookstoreId))
                .FirstOrDefaultAsync();

            if(inventory is null || inventory.Stock == 0)
            {
                return StatusCodes.Status400BadRequest;
            } 
            
            // 2.Arange
            var order = new Order()
            {
                Customer = email,
                Inventory = inventory,
                Amount = 1,
                Price = inventory.Price
            };

            // 3.Act
            inventory.Stock -= 1;
            Context.Add(order);

            // 4. Assert
            var affected = await Context.SaveChangesAsync();
            if (affected == 0)
            {
                return StatusCodes.Status500InternalServerError;
            }

            return StatusCodes.Status201Created;
        }
    }
}
