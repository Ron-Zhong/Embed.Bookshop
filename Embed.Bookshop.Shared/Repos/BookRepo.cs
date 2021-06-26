using Embed.Bookshop.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Embed.Bookshop.Repos
{
    public interface IBookRepo
    {
        IQueryable<BookDTO> QueryAll();
        Task<List<BookDTO>> SearchAsync(string keyword);
        Task<BookDTO> GetAsync(string isbn);
    }

    public class BookRepo : IBookRepo
    {
        public BookRepo(DBContext context)
        {
            Context = context;
        }

        DBContext Context { get; }

        public IQueryable<BookDTO> QueryAll()
        {
            return Context.Inventories
                .GroupBy(x => x.ISBN)
                .Select(x => new BookDTO()
                {
                    ISBN = x.Key,
                    BookName = x.Max(y => y.BookName),
                    Author = x.Max(y => y.Author),
                    Stock = x.Sum(i => i.Stock),
                    MaxPrice = x.Max(i => i.Price),
                    MinPrice = x.Min(i => i.Price),
                });
        }


        public async Task<List<BookDTO>> SearchAsync(string keyword)
        {
            return await QueryAll().Where(x => x.BookName.Contains(keyword) || x.Author.Contains(keyword) || x.ISBN.Contains(keyword)).ToListAsync();
        }

        public async Task<BookDTO> GetAsync(string keyword)
        {
            var book = await QueryAll()
                            .Where(x => x.BookName.Contains(keyword) || x.Author.Contains(keyword) || x.ISBN.Contains(keyword))
                        .FirstOrDefaultAsync();

            if (book is null)
            {
                return null;
            }

            book.Stocks = await Context.Inventories
                .Where(x => x.ISBN.Equals(book.ISBN))
                .Select(x => new StockDTO()
                {
                    BookstoreId = x.Bookstore.Id,
                    BookstoreName = x.Bookstore.Name,
                    Price = x.Price,
                    Stock = x.Stock,
                }).ToListAsync();

            return book;
        }
    }
}
