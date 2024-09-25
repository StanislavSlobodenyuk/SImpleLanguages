using Domain.Entity.Content.Question;
using Domain.Entity.Content.Lessons;

namespace Dal.Interfaces.LessonRepositories
{
    public interface ILessonRepository : IBaseRepository<Lesson>
    {
        Task<Lesson?> GetLecture(int lessonId);
        Task<Lesson?> GetPractice(int lessonId);

        Task<Lesson?> ChangeAvailableLesson(Lesson lesson);

        Task<bool> AddQuestionToLesson(Lesson lesson, List<BaseQuestion> question);
        Task<bool> DeleteQuestionFromLesson(Lesson lesson, BaseQuestion question);

        Task<bool> AddLecture(Lesson lesson, LectureBlock lecture);
        Task<bool> DeleteLecture(Lesson lesson, LectureBlock lecture);
    }
}
