// See https://aka.ms/new-console-template for more information
using EFCoreDemo.Infrastructure;

Console.WriteLine("Hello, This is an example of ef core left join.");

using var context = new ApplicationDbContext();

var result = context.Authors
                    .GroupJoin(context.Books,
                               author => author.Id,
                               book => book.AuthorId,
                               (author, books) => new { Author = author, Books = books.DefaultIfEmpty() })
                    .SelectMany(x => x.Books.Select(book => new
                    {
                        AuthorName = x.Author.Name,
                        BookTitle = book != null ? book.Title : "No Book"
                    }))
                    .ToList();

foreach (var item in result)
{
    Console.WriteLine($"Author Name: { item.AuthorName }, Book Title: { item.BookTitle }");
}