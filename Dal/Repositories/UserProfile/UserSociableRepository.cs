using Dal.Interfaces.UserProfile;
using Domain.Entity.User;
using Domain.Entity.User.UserProfile;
using Microsoft.EntityFrameworkCore;

namespace Dal.Repositories.UserProfile
{
    public class UserSociableRepository : IUserSociableRepository
    {
        private readonly ApplicationDbContext _context;

        public UserSociableRepository(ApplicationDbContext context) 
        {
            _context = context;
        }
        public async Task<IEnumerable<UserSociable>> GetAllUserSociables(string userId)
        {
            return await _context.UserSociables
                .Where(x => x.UserId == userId)
                .ToListAsync();
        }

        public async Task<UserSociable?> GetById(int id)
        {
            return await _context.UserSociables.FindAsync(id);
        }
        public async Task<bool> Create(UserSociable entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            var existSociable =  await _context.UserSociables.FirstOrDefaultAsync(x => x.UserId == entity.UserId);

            if (existSociable != null)
                throw new InvalidOperationException($"{entity.Sociable} is exist");

            var newUserSociable = new UserSociable()
            {
                UserId = entity.UserId,
                Link = entity.Link,
                IconPath = entity.IconPath,
                Sociable = entity.Sociable,
            };

            await _context.UserSociables.AddAsync(newUserSociable);

            var result = await _context.SaveChangesAsync();
            return result > 0;
        }
        public async Task<bool> Update(UserSociable entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            var existSociable = await _context.UserSociables
                .FirstOrDefaultAsync(x => x.UserId == entity.UserId && x.Sociable == entity.Sociable);

            if (existSociable == null)
                throw new InvalidOperationException($"{entity.Sociable} does not exist");

            existSociable.Link = entity.Link;

            _context.UserSociables.Update(existSociable);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }
        public async Task<bool> Delete(UserSociable entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            var existSociable = await _context.UserSociables.FirstOrDefaultAsync(x => x.UserId == entity.UserId);

            if (existSociable == null)
                throw new InvalidOperationException($"{entity.Sociable} is`nt exist");


             _context.UserSociables.Remove(existSociable);

            var result = await _context.SaveChangesAsync();
            return result > 0;
        }
    }
}
