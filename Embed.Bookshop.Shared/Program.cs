
using System;
using System.Linq;
using Embed.Bookshop;
using Embed.Bookshop.Repos;

var context = new DBContext();
var OrderRepo = new OrderRepo(context);
//var BookRepo = new BookRepo(context);

//var books = BookRepo.QueryAll().ToList();

//books.ForEach(x =>
//{
//    Console.WriteLine($"{x.ISBN} {x.BookName} {x.Author} - {x.Stock} (${x.MinPrice} ~ ${x.MaxPrice})");
//});


//var book = await BookRepo.GetAsync("Book A");
//Console.WriteLine($"{book.BookName} ({book.Stock})");

//book.Stocks.ForEach(x =>
//{
//    Console.WriteLine($"\t{x.BookstoreName} ({x.Stock})" );
//});



var result = await OrderRepo.CreateAsync("2830440150651", new Guid("10e340a7-36ac-4a7d-d795-08d938603709"), "ron.zhong@gmail.com");

Console.WriteLine(result);