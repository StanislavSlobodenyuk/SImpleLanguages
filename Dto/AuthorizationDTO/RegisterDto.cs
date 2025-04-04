using Domain.Enum;

namespace Dto.AuthorizationDTO
{
    public class RegisterDto
    {
        public string UserName { get; set; }  = string.Empty;
        public string UserEmail {  get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public LanguageName NativeLanguage { get; set; } 
        public LanguageName TargetLanguage { get; set; }
        public LanguageLevel TargetLevelLanguage { get; set; }
    }
}
