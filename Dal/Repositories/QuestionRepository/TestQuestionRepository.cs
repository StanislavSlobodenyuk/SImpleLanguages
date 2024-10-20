
using Dal.Interfaces.QuestionRepository;
using Domain.Entity.Content.Question;
using Microsoft.EntityFrameworkCore;

namespace Dal.Repositories.QuestionRepository
{
    public class TestQuestionRepository : ITestQuestionRepository
    {
        private readonly ApplicationDbContext _context;

        public TestQuestionRepository(ApplicationDbContext context)
        {
            _context = context;
        }
    }
}
