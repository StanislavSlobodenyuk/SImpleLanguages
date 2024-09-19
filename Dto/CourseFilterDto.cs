
using Domain.Enum;

namespace Dto
{
    public class CourseFilterDto
    {
        public string? SearchName { get; set; }
        public LanguageName Language { get; set; }
        public LanguageLevel Difficult { get; set; }

    }
}
