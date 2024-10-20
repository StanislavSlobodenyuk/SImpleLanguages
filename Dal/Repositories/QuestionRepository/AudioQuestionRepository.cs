
using Dal.Interfaces.QuestionRepository;
using Domain.Entity.Content.Question;
using Microsoft.EntityFrameworkCore;

namespace Dal.Repositories.QuestionRepository
{
    public class AudioQuestionRepository : IAudioQuestionRepository
    {
        private readonly ApplicationDbContext _context;
        public AudioQuestionRepository(ApplicationDbContext context)
        {
            _context = context;
        }
    }
}
