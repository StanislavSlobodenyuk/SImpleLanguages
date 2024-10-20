
using Dal.Interfaces.QuestionRepository;
using Domain.Entity.Content.Question;
using Domain.Enum;
using Microsoft.EntityFrameworkCore;

namespace Dal.Repositories.QuestionRepository
{
    public class BaseQuestionRepository : IBaseQuestionRepository
    {
        private readonly ApplicationDbContext _context;

        public BaseQuestionRepository( ApplicationDbContext context)
        {
            _context = context;
        }
    }
}
