using Domain.Entity.Content.Lessons;

namespace Dal.Interfaces.LessonRepositories
{
    public interface IlectureRepository : IBaseRepository<LectureBlock>
    {
        Task<LectureBlock?> UpdateContent(int lectureId, string content);
        Task<LectureBlock?> AddImage(int lectureId, int imageId);
        Task<LectureBlock?> UpdateImage(int lectureId, string text);
    }
}
