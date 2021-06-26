using Embed.Bookshop.DTO;
using Embed.Bookshop.Repos;
using Microsoft.AspNetCore.Http;
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
    public class BookshopApiController : ControllerBase
    {
        public BookshopApiController(IBookRepo bookRepo, IOrderRepo orderRepo)
        {
            BookRepo = bookRepo;
            OrderRepo = orderRepo;
        }

        public IBookRepo BookRepo { get; }
        public IOrderRepo OrderRepo { get; }

        /// <summary>
        /// 1.	A method to return a list of available books
        /// </summary>
        [HttpGet]
        [Route("~/api/books")]
        public async Task<List<BookDTO>> GetAll()
        {
            var books = await BookRepo.QueryAll().ToListAsync();

            return books;
        }
        /// <summary>
        /// 2.	A search method to find a book by containing string. It returns the data in the same format as method 1
        /// </summary>
        /// <param name="keyword" example="new book"></param>
        [HttpGet]
        [Route("~/api/search/{keyword}")]
        public async Task<ActionResult> SearchBookAsync(string keyword)
        {
            var books = await BookRepo.SearchAsync(keyword);

            return Ok(books);
        }

        /// <summary>
        /// 3.	A method to return information about a specific book
        /// </summary>
        /// <param name="isbn" example="4882978795968"></param>
        [HttpGet]
        [Route("~/api/books/{isbn}")]
        public async Task<ActionResult> GetBookAsync(string isbn)
        {
            var book = await BookRepo.GetAsync(isbn);

            if (book is null)
            {
                return NotFound();
            }

            return Ok(book);
        }


        /// <summary>
        /// 4.	A method to create an order for a specific book from a specific store
        /// </summary>
        /// <param name="isbn" example="8954884915612"></param>
        /// <param name="bookstoreId" example="10e340a7-36ac-4a7d-d795-08d938603709"></param>
        /// <param name="email" example="ron.zhong@gmail.com"></param>
        /// <response code="201">Created</response>
        /// <response code="400">Bad Request</response>   
        /// <response code="404">Book or Bookstore not found</response>   
        /// <response code="500">Transaction Error</response>   
        [HttpPost]
        [Route("~/api/orders")]
        public async Task<ActionResult> PlaceNewOrder(string isbn, Guid bookstoreId, string email)
        {
            if(email.IsValidEmail() == false)
            {
                return BadRequest("Must enter a valid email address");
            }

            var statusCode = await OrderRepo.CreateAsync(isbn, bookstoreId, email);

            if(statusCode != StatusCodes.Status201Created)
            {
                return StatusCode(statusCode);
            }

            return Created(Request.Path,"Order succesfully placed!!");
        }


    }
}
