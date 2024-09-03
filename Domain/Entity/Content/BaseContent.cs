
using Domain.Entity.Base;
using Domain.Entity.Content.Metadata.Course;

namespace Domain.Entity.Content
{
    public class BaseContent : BaseEntity
    {
        public string? Title { get; private set; }

        public int LanguageCourseId { get; private set; }
        public Course? LanguageCourse { get; private set; }

        public BaseContent(string title, int languageId)
        {
            Title = title ?? throw new ArgumentNullException(nameof(title));
            LanguageCourseId = languageId;
        }
    }
}
