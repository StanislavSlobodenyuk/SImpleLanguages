
using Domain.Entity.Base;
using Domain.Entity.Content.CourseContent;

namespace Domain.Entity.User.UserProgress
{

    public class CourseUserProgress : BaseEntity
    {
        public int UserId { get; set; }
        public User User { get; set; } = new User();

        public int CourseId { get; set; }
        public Course Course { get; set; } = new Course();

        public int CompletedLessons { get; set; } = 0;

        public int CompletedStories { get; set; } = 0;

        public int CompletedGrammars { get; set; } = 0;

        public int LearnedWordsInCourse { get; set; } = 0;
    }
}

