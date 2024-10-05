using EFCoreDemo.Domain.Audit;

namespace EFCoreDemo.Domain.Users
{
    public sealed class UserProfile : Auditable
    {
        public string Bio { get; set; }

        // Foreign key
        public Guid UserId { get; set; }

        // Navigation property to the user
        public User User { get; set; }
    }
}
