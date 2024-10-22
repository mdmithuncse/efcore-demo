using EFCoreDemo.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreDemo.Infrastructure
{
    internal sealed class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title)
                   .HasMaxLength(50)
                   .IsRequired();

            builder.HasOne(b => b.Author)
                   .WithMany(a => a.Books) 
                   .HasForeignKey(b => b.AuthorId)
                   .HasPrincipalKey(a => a.Id);
        }
    }
}