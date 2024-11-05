using Domain.Entity.Base;
using Domain.Entity.Content.CourseContent;

namespace Domain.Entity.Content
{
    public abstract class BaseContentCourse : BaseEntity
    {
        public int CourseId { get;  set; }
        public Course? Course { get; private set; }

        protected BaseContentCourse() { }
    }
}
