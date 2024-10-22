// See https://aka.ms/new-console-template for more information
using EFCoreDemo.Infrastructure;

Console.WriteLine("Hello, This is an example of ef core right join.");

using var context = new ApplicationDbContext();

var result = context.Books
                    .GroupJoin(context.Authors,
                               book => book.AuthorId,
                               author => author.Id,
                               (book, authors) => new { Book = book, Authors = authors.DefaultIfEmpty() })
                    .SelectMany(x => x.Authors.Select(author => new
                    {
                        BookTitle = x.Book.Title,
                        AuthorName = author != null ? author.Name : "No Author"
                    }))
                    .ToList();

foreach (var item in result)
{
    Console.WriteLine($"Author Name: { item.AuthorName }, Book Title: { item.BookTitle }");
}