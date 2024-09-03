using Domain.Entity.Base;
using Domain.Entity.Content.Image;
using Domain.Entity.Content.Question;

namespace Domain.Entity.Content.Lessons
{
    public class Lesson : BaseEntity 
    {
        public int ModuleOflessonsId { get; private set; }
        public ModuleOfLessons? ModuleOfLessons { get; private set; }

        public int ImageId { get;  private set; }
        public MyImage? Image { get; set; }

        public ICollection<BaseQuestion> Questions { get; private set; } = new List<BaseQuestion>();

        public Lesson(int moduleOflessonsId, int imageId)
        {
            ModuleOflessonsId = moduleOflessonsId;
            ImageId = imageId;
        }
    }
}
