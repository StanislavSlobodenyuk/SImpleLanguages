
using Common.Response;
using Domain.Entity.Content.Lessons;
using Domain.Entity.Content.Question;
using Domain.Enum;

namespace Service.Interfaces
{
    public interface ILessonService
    {
        Task<BaseResponse<Lesson>> Create(string Title, LanguageLevel difficult, bool isavailable, string iconpath);
        Task<BaseResponse<bool>> Delete(int lessonId);
        Task<BaseResponse<Lesson>> UpdateIcon(int lessonId, string iconpath);
        Task<BaseResponse<Lesson>> UpdateTitle(int lessonId, string title);
        Task<BaseResponse<Lesson>> ChangeAvailable(int lessonId, bool isAvailable);
        
        Task<BaseResponse<Lesson>> GetLesson(int lessonId);

        Task<BaseResponse<BaseQuestion>> AddQuestion(int lessonId, BaseQuestion question);
        Task<BaseResponse<bool>> DeleteQuestion(int lessonId, BaseQuestion question);
        Task<BaseResponse<List<bool>>> DeleteAllQuestion(int lessonId, List<BaseQuestion> questions); 


        Task<BaseResponse<IEnumerable<BaseQuestion>>> GetAllQuestionForThisLesson(int lessonId);
    }
}
