using Domain.Entity.Base;
using Domain.Entity.Content.CourseContent;
using Domain.Entity.Content.DictionaryContent;

namespace Domain.Entity.Content
{
    public class CourseWord : BaseContentCourse
    {
        public int DictionaryId { get; set; }
        public MyDictionary Dictionary { get; set; } = null!;

    }
}
