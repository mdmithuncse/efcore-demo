// See https://aka.ms/new-console-template for more information
using EFCoreDemo.Infrastructure;

Console.WriteLine("Hello, This is an example of ef core inner join.");

using var context = new ApplicationDbContext();

var result = context.Authors
                    .Join(context.Books,
                          author => author.Id,
                          book => book.AuthorId,
                          (author, book) => new
                          {
                              AuthorName = author.Name,
                              BookTitle = book.Title
                          })
                    .ToList();

foreach (var item in result)
{
    Console.WriteLine($"Author Name: { item.AuthorName }, Book Title: { item.BookTitle }");
}