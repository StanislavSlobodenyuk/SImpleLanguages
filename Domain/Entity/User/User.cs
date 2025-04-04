
using Domain.Enum;
using Microsoft.AspNetCore.Identity;

namespace Domain.Entity.User
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; } = String.Empty;
        public string LastName { get; set; } = String.Empty;
        public DateTime Birthday { get; set; }
        public string UserIcon { get; set; } = String.Empty;
        public LanguageName NativeLanguage { get; set; }
    }
}
