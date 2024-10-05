using EFCoreDemo.Domain.Audit;

namespace EFCoreDemo.Domain.Users
{
    public sealed class User : Auditable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string FullName => $"{ FirstName } { LastName }";

        // Navigation property to the profile
        public UserProfile Profile { get; set; }
    }
}
