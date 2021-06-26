using Embed.Bookshop.DTO;
using Embed.Bookshop.Repos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Embed.Bookshop.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        public BookController(IBookRepo bookRepo)
        {
            BookRepo = bookRepo;
        }

        public IBookRepo BookRepo { get; }


        [HttpGet]
        [Route("~/api/books")]
        public async Task<List<BookDTO>> GetAll()
        {
            var books = await BookRepo.QueryAll()
                .ToListAsync();

            return books;
        }


        [HttpGet]
        [Route("~/api/books/search/{keyword}")]
        public async Task<ActionResult> SearchBookAsync(string keyword)
        {
            var book = await BookRepo.SearchAsync(keyword);

            if(book is null)
            {
                return NotFound();
            }

            return Ok(book);
        }
    }
}
