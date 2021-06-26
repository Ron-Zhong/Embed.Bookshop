
using System;
using System.Linq;
using Embed.Bookshop;
using Embed.Bookshop.Repos;

var context = new DBContext();
var BookRepo = new BookRepo(context);

var books = BookRepo.QueryAll().ToList();

books.ForEach(x =>
{
    Console.WriteLine($"{x.ISBN} {x.BookName} {x.Author} - {x.Stock} (${x.MinPrice} ~ ${x.MaxPrice})");
});


var book = await BookRepo.SearchAsync("Book A");
Console.WriteLine($"{book.BookName} ({book.Stock})");

book.Stocks.ForEach(x =>
{
    Console.WriteLine($"\t{x.BookstoreName} ({x.Stock})" );
});



