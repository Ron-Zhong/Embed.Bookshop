using System;
using System.Linq;
using Embed.Bookshop;
using Embed.Bookshop.Common;
using Embed.Bookshop.Entities;

// 1.Arrange
var CustomerEmail = "ron.zhong@gmail.com";

var BookstoreA = new Bookstore() { Name = "Bookstore A" };
var BookstoreB = new Bookstore() { Name = "Bookstore B" };

var BookA = new Book(ISBN: Helper.GenerateISBN(), Author: "Author A", Name: "Book A");
var BookB = new Book(ISBN: Helper.GenerateISBN(), Author: "Author B", Name: "Book B");
var BookC = new Book(ISBN: Helper.GenerateISBN(), Author: "Author C", Name: "Book C");


// 2.Act
var context = new DBContext();

//SeedBookstores(context);
//SeedInventories(context);
//SeedOrders(context);





void SeedBookstores(DBContext context)
{
    context.Bookstores.Add(BookstoreA);
    context.Bookstores.Add(BookstoreB);

    context.SaveChanges();
}

void SeedInventories(DBContext context)
{
    var bookstoreA = context.Bookstores.Where(x => x.Name.Equals(BookstoreA.Name)).FirstOrDefault();
    context.Add(new Inventory() { Bookstore = bookstoreA, BookName = BookA.Name, ISBN = BookA.ISBN, Author = BookA.Author, Stock = Helper.GenerateStock(), Price = Helper.GeneratePrice() });
    context.Add(new Inventory() { Bookstore = bookstoreA, BookName = BookB.Name, ISBN = BookB.ISBN, Author = BookB.Author, Stock = Helper.GenerateStock(), Price = Helper.GeneratePrice() });
    context.Add(new Inventory() { Bookstore = bookstoreA, BookName = BookC.Name, ISBN = BookC.ISBN, Author = BookC.Author, Stock = Helper.GenerateStock(), Price = Helper.GeneratePrice() });


    var bookstoreB = context.Bookstores.Where(x => x.Name.Equals(BookstoreB.Name)).FirstOrDefault();
    context.Add(new Inventory() { Bookstore = bookstoreB, BookName = BookA.Name, ISBN = BookA.ISBN, Author = BookA.Author, Stock = Helper.GenerateStock(), Price = Helper.GeneratePrice() });
    context.Add(new Inventory() { Bookstore = bookstoreB, BookName = BookB.Name, ISBN = BookB.ISBN, Author = BookB.Author, Stock = Helper.GenerateStock(), Price = Helper.GeneratePrice() });
    context.Add(new Inventory() { Bookstore = bookstoreB, BookName = BookC.Name, ISBN = BookC.ISBN, Author = BookC.Author, Stock = Helper.GenerateStock(), Price = Helper.GeneratePrice() });

    context.SaveChanges();
}


void SeedOrders(DBContext context)
{
    var inventoryA = context.Inventories.Where(x => x.BookName.Contains(BookA.Name) && x.Stock > 0).FirstOrDefault();
    var inventoryB = context.Inventories.Where(x => x.BookName.Contains(BookB.Name) && x.Stock > 0).FirstOrDefault();
    var inventoryC = context.Inventories.Where(x => x.BookName.Contains(BookC.Name) && x.Stock > 0).FirstOrDefault();

    context.Add(new Order() { Customer = CustomerEmail, Amount = Helper.GeneratePurchase(), Inventory = inventoryA, Price = inventoryA.Price });
    context.Add(new Order() { Customer = CustomerEmail, Amount = Helper.GeneratePurchase(), Inventory = inventoryB, Price = inventoryB.Price });
    context.Add(new Order() { Customer = CustomerEmail, Amount = Helper.GeneratePurchase(), Inventory = inventoryC, Price = inventoryC.Price });

    context.SaveChanges();
}