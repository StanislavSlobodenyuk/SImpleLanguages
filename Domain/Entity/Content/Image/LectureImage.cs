
using Domain.Entity.Base;
using Domain.Entity.Content.Lessons;

namespace Domain.Entity.Content.Image
{
    public class LectureImage : BaseEntity
    {
        public int LectureId { get; set; }
        public LectureBlock? Lecture{ get; set; }

        public int ImageId { get; set; }
        public MyImage? Image { get; set; }
    }
}
