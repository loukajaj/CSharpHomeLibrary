using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication5.Models;

namespace WebApplication5.DAL
{
    public class BookInitializer : DropCreateDatabaseIfModelChanges<BookContext>
    {
        protected override void Seed(BookContext context)
        {
            var authors = new List<Author>
            {
                new Author {
                    Biography = "...",
                    FirstName = "Kalle",
                    LastName = "Kuula",
                    Books = new List<Book>()
                },
                new Author {
                    Biography = "...",
                    FirstName = "Jesse",
                    LastName = "Jäälinna",
                    Books = new List<Book>()
                }
            };

            authors.ForEach(a => context.Authors.Add(a));
            context.SaveChanges();

            var books = new List<Book>
            {
                new Book {
                   Authors = new List<Author>(),
                   Description = "...",
                   ImageUrl = "http://ecx.images-amazon.com/images/I/51T%2BWt430bL._AA160_.jpg",
                   Isbn = "1491914319",
                   Synopsis = "...",
                   Title = "Knockout.js: Building Dynamic Client-Side Web Applications"
                },
                new Book {
                   Authors = new List<Author>(),
                   Description = "...",
                   ImageUrl = "http://ecx.images-amazon.com/images/I/51AkFkNeUxL._AA160_.jpg",
                   Isbn = "1449319548",
                   Synopsis = "...",
                   Title = "20 Recipes for Programming PhoneGap: Cross-Platform Mobile Development"
                },
                new Book {
                   Authors = new List<Author>(),
                   Description = "...",
                   ImageUrl = "http://ecx.images-amazon.com/images/I/51LpqnDq8-L._AA160_.jpg",
                   Isbn = "1449309860",
                   Synopsis = "...",
                   Title = "20 Recipes for Programming MVC 3: Faster, Smarter Web Development"
                },
                new Book {
                   Authors = new List<Author>(),
                   Description = "...",
                   ImageUrl = "http://ecx.images-amazon.com/images/I/41JC54HEroL._AA160_.jpg",
                   Isbn = "1460954394",
                   Synopsis = "...",
                   Title = "Rapid Application Development With CakePHP"
               }
            };

            books.ForEach(b => context.Books.Add(b));
            context.SaveChanges();

            AddAuthor(context, "Knockout.js: Building Dynamic Client-Side Web Applications", "Jäälinna");
            AddAuthor(context, "20 Recipes for Programming PhoneGap: Cross-Platform Mobile Development", "Jäälinna");
            AddAuthor(context, "20 Recipes for Programming MVC 3: Faster, Smarter Web Development", "Kuula");
            AddAuthor(context, "Rapid Application Development With CakePHP", "Kuula");
        }

        void AddAuthor(BookContext context, string title, string lastName)
        {
            var book = context.Books.SingleOrDefault(b => b.Title == title);
            var auth = book.Authors.SingleOrDefault(i => i.LastName == lastName);
            if (auth == null)
                book.Authors.Add(context.Authors.Single(i => i.LastName == lastName));
        }
    }
}