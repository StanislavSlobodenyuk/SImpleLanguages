using Domain.Entity.Base;
using Domain.Entity.Content.CourseContent;
using System.Text.Json.Serialization;

namespace Domain.Entity.Content
{
    public abstract class BaseContentCourse : BaseEntity
    {
        public int CourseId { get;  set; }
        [JsonIgnore]
        public Course? Course { get; private set; }

        protected BaseContentCourse() { }
    }
}
