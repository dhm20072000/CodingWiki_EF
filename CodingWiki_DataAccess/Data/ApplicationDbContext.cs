using CodingWiki_DataAccess.FluentConfig;
using CodingWiki_Model.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingWiki_DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<BookDetail> BookDetails { get; set; }
        public DbSet<BookAuthorMap> BookAuthorMaps { get; set; }
        public DbSet<Fluent_BookDetail> BookDetails_Fluent { get; set; }
        public DbSet<Fluent_Book> Fluent_Books { get; set; }
        public DbSet<Fluent_Author> Fluent_Authors { get; set; }
        public DbSet<Fluent_Publisher> Fluent_Publishers { get; set; }
        public DbSet<Fluent_BookAuthorMap> Fluent_BookAuthorMaps { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            //options.UseSqlServer("Server=LAPTOP-7QETP18L\\OMEGA365SQL;Database=CodingWiki;TrustServerCertificate=True;Trusted_Connection=True;")
            //    .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().Property(u => u.Price).HasPrecision(10,5);

            modelBuilder.Entity<BookAuthorMap>().HasKey(u => new { u.Author_Id, u.Book_Id });

            modelBuilder.ApplyConfiguration(new FluentAuthorConfig());
            modelBuilder.ApplyConfiguration(new FluentBookAuthorMapConfig());
            modelBuilder.ApplyConfiguration(new FluentBookConfig());
            modelBuilder.ApplyConfiguration(new FluentBookDetailConfig());
            modelBuilder.ApplyConfiguration(new FluentPublisherConfig());

            modelBuilder.Entity<Book>().HasData(
                new Book { BookId = 1, Title = "Spider without Duty", ISBN = "1234567890", Price = 10.99m, Publisher_Id = 1 },
                new Book { BookId = 2, Title = "Fortune of time", ISBN = "1234567891", Price = 11.99m, Publisher_Id = 1 }
            );

            var bookList = new Book[]
            {
                new Book { BookId = 3, Title = "Mystery of the Old House", ISBN = "1234567892", Price = 12.99m, Publisher_Id = 2 },
                new Book { BookId = 4, Title = "Adventures in Coding", ISBN = "1234567893", Price = 13.99m, Publisher_Id = 2 },
                new Book { BookId = 5, Title = "The Last Algorithm", ISBN = "1234567894", Price = 14.99m, Publisher_Id = 3 }
            };

            modelBuilder.Entity<Book>().HasData(bookList);

            modelBuilder.Entity<Publisher>().HasData(
                new Publisher { Publisher_Id = 1, Name = "Tech Books Publishing", Location = "Chicago" },
                new Publisher { Publisher_Id = 2, Name = "Fiction House", Location = "New York" },
                new Publisher { Publisher_Id = 3, Name = "Science Press", Location = "San Francisco" }
            );
        }
    }
}
