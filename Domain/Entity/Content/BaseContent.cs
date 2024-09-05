
using Domain.Entity.Base;
using Domain.Entity.Content.Metadata.Course;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entity.Content
{
    public abstract class BaseContent : BaseEntity
    {
        public string? Title { get; private set; }

        public int LanguageCourseId { get; private set; }
        public LanguageCourse? LanguageCourse { get; private set; }

        protected BaseContent(string title, int languageCourseId)
        {
            LanguageCourseId = languageCourseId;
            Title = title ?? throw new ArgumentNullException(nameof(title));
        }
        protected BaseContent() { }
    }
}
