using EFCoreDemo.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreDemo.Infrastructure
{
    internal sealed class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                   .HasMaxLength(50)
                   .IsRequired();
        }
    }
}