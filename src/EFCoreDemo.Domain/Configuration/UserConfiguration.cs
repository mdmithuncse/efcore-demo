using EFCoreDemo.Domain.Audit;
using EFCoreDemo.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreDemo.Domain.Configuration
{
    internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(auditable => auditable.Id);

            builder.Property(auditable => auditable.CreatedBy)
                .IsRequired();

            builder.Property(auditable => auditable.CreatedOn)
                .IsRequired();

            builder.Property(user => user.FirstName)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(user => user.LastName)
                .HasMaxLength(20)
                .IsRequired();

            builder.Ignore(user => user.FullName);

            builder.HasOne(user => user.Profile)
                .WithOne(profile => profile.User)
                .HasForeignKey<UserProfile>(profile => profile.UserId);
        }
    }
}
