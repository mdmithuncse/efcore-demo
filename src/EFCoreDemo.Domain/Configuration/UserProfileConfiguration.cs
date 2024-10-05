using EFCoreDemo.Domain.Audit;
using EFCoreDemo.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreDemo.Domain.Configuration
{
    internal sealed class UserProfileConfiguration : IEntityTypeConfiguration<UserProfile>
    {
        public void Configure(EntityTypeBuilder<UserProfile> builder)
        {
            builder.HasKey(auditable => auditable.Id);

            builder.Property(auditable => auditable.CreatedBy)
                .IsRequired();

            builder.Property(auditable => auditable.CreatedOn)
                .IsRequired();

            builder.Property(userprofile => userprofile.Bio)
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}
