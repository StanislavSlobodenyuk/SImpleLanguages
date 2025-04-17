using Dal.Interfaces.LearnContent;
using Domain.Entity.Content.Achievments;
using Microsoft.EntityFrameworkCore;

namespace Dal.Repositories.LearnContent
{
    public class AchievementRepository : IAchievementRepository
    {
        private readonly ApplicationDbContext _context;

        public AchievementRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Achievement>> GetAchievements()
        {
            return await _context.Achievements.ToListAsync();
        }

        public async Task<Achievement?> GetById(int id)
        {
            return await _context.Achievements.FindAsync(id);
        }
        public async Task<bool> Create(Achievement entity)
        {
            var exist = await _context.Achievements.FindAsync(entity.Title);       
            
            await _context.Achievements.AddAsync(entity);

            var changes = await _context.SaveChangesAsync();
            return changes > 0;

        }
        public async Task<bool> Update(Achievement newEntity)
        {
            _context.Achievements.Update(newEntity);

            var changes = await _context.SaveChangesAsync();
            return changes > 0;
        }
        public async Task<bool> Delete(Achievement entity)
        {
            var exist = await _context.Achievements.FindAsync(entity.Title);

            _context.Achievements.Remove(entity);

            var changes = await _context.SaveChangesAsync();
            return changes > 0;
        }

        public async Task SaveChangeAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
