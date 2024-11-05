using Dal.Interfaces;
using Domain.Entity.Content.Lessons;
using Microsoft.EntityFrameworkCore;

namespace Dal.Repositories
{
    public class TheoryRepository : ITheoryRepository
    {
        private readonly ApplicationDbContext _context;

        public TheoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<Theory?> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Theory>> GetTheories(int lessonId)
        {
            return await _context.Theories.Where(t => t.LessonId == lessonId).ToListAsync();
        }

        public Task<bool> Create(Theory entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(Theory entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Theory entity)
        {
            throw new NotImplementedException();
        }
    }
}
