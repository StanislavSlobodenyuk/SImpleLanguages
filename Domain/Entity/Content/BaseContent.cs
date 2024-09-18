
using Domain.Entity.Base;
using Domain.Entity.Content.Metadata.Course;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entity.Content
{
    public abstract class BaseContent : BaseEntity
    {
        public int LanguageCourseId { get; private set; }
        public LanguageCourse? LanguageCourse { get; private set; }

        protected BaseContent() { }
    }
}
