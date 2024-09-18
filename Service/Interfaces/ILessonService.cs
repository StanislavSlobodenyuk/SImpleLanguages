
using Common.Response;
using Domain.Entity.Content.Lessons;
using Domain.Entity.Content.Question;
using Domain.Enum;

namespace Service.Interfaces
{
    public interface ILessonService
    {
        Task<BaseResponse<Lesson>> Create(string Title, bool isavailable, string iconpath);
        Task<BaseResponse<bool>> Delete(int lessonId);
        Task<BaseResponse<Lesson>> UpdateIcon(int lessonId, string iconpath);
        Task<BaseResponse<Lesson>> UpdateTitle(int lessonId, string title);
        Task<BaseResponse<Lesson>> ChangeAvailable(int lessonId, bool isAvailable);
        
        Task<BaseResponse<Lesson>> GetLesson(int lessonId);


        Task<BaseResponse<Lesson>> AddLecture(LectureBlock lecture, int lessonId);
        Task<BaseResponse<Lesson>> DeleteLecture(LectureBlock lecture, int lessonId);


        Task<BaseResponse<Lesson>> AddQuestion(int lessonId, BaseQuestion question);
        Task<BaseResponse<Lesson>> DeleteQuestion(int lessonId, BaseQuestion question);
        Task<BaseResponse<Lesson>> DeleteAllQuestion(int lessonId, List<BaseQuestion> questions); 


        Task<BaseResponse<IEnumerable<BaseQuestion>>> GetAllQuestionForThisLesson(int lessonId);
    }
}
