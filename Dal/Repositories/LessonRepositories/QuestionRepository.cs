
using Dal.Interfaces.LessonRepositories;
using Domain.Entity.Content.Lessons;
using Domain.Entity.Content.Question;
using Domain.Enum;
using Microsoft.EntityFrameworkCore;

namespace Dal.Repositories.QuestionRepository
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly ApplicationDbContext _context;

        public QuestionRepository( ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<bool> DeleteQuestion(Lesson lesson, BaseQuestion question)
        {
            throw new NotImplementedException();
        }

        public Task<BaseQuestion?> GetQuestion(int questionId, TypeQuestion type)
        {
            throw new NotImplementedException();
        }
    }
}
