// See https://aka.ms/new-console-template for more information
using CodingWiki_DataAccess.Data;
using CodingWiki_Model.Models;
using Microsoft.EntityFrameworkCore;
using static System.Reflection.Metadata.BlobBuilder;

Console.WriteLine("Hello, World!");

//using(ApplicationDbContext context = new()) {
//    context.Database.EnsureCreated();
//    if(context.Database.GetPendingMigrations().Count() > 0)
//    {
//        context.Database.Migrate();
//    }
//}

//AddBook();

//GetAllBooks();
//GetBook();
//UpdateBook();
//DeleteBook();

//async void DeleteBook()
//{
//    try
//    {
//        using var context = new ApplicationDbContext();
//        var book = await context.Books.FindAsync(7);
//        context.Books.Remove(book);
//        await context.SaveChangesAsync();
//    }
//    catch (Exception ex)
//    {
//        Console.WriteLine(ex.Message);
//    }
//}

//void UpdateBook()
//{
//    try
//    {
//        using var context = new ApplicationDbContext();
//        var book = context.Books.Find(7);
//        book.ISBN = "777";
//        context.SaveChanges();
//    }
//    catch (Exception ex)
//    {
//        Console.WriteLine(ex.Message);
//    }
//}

//void GetBook()
//{
//    try
//    {
//        using var context = new ApplicationDbContext();
//        var books = context.Books.OrderBy(u => u.BookId);
//        //Console.WriteLine(book.Title + " - " + book.ISBN);
//        //if (book != null)
//        //{
//        //    Console.WriteLine(book.Title + " - " + book.ISBN);
//        //}

//        foreach (var book in books)
//        {
//            Console.WriteLine(book.Title + " - " + book.ISBN);
//        }
//    }
//    catch(Exception ex)
//    {
//        Console.WriteLine(ex.Message);
//    }
//}

//void GetAllBooks()
//{
//    using var context = new ApplicationDbContext();
//    var books = context.Books.ToList();

//    foreach (var book in books)
//    {
//        Console.WriteLine(book.Title + " - " + book.ISBN);
//    }
//}

//void AddBook()
//{
//    Book book = new() { Title = "New EF Core Book", ISBN = "123123123", Price = 10.93m, Publisher_Id = 1 };
//    using var context = new ApplicationDbContext();
//    context.Books.Add(book);
//    context.SaveChanges();
//}