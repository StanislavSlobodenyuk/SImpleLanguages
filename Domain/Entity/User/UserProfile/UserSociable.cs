using Domain.Entity.Base;
using Domain.Enum;

namespace Domain.Entity.User.UserProfile
{
    public class UserSociable : BaseEntity
    {
        public SociableType Sociable { get; set; }
        public string Link {  get; set; } = string.Empty ;
        public string IconPath { get; set; } = string.Empty;

        public User User { get; set; } = new User();
        public string UserId { get; set; } = string.Empty;

        public UserSociable(){}
        public UserSociable(SociableType sociable, string link)
        {
            Sociable = sociable;    
            Link = link;    
        }
    }
}

