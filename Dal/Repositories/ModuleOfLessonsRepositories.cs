
using Dal.Interfaces;
using Domain.Entity.Content.Lessons;
using Domain.Entity.Content.Metadata.Course;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace Dal.Repositories
{
    public class ModuleOfLessonsRepositories : IModuleOfLessonsRepository
    {
        private readonly ApplicationDbContext _context;
        public ModuleOfLessonsRepositories(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Add(ModuleOfLessons entity)
        {
            if (entity == null || entity.Id == 0) return false;

            try
            {
                await _context.ModuleOfLessons.AddAsync(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException)
            {
                return false;
            }
        }
        public async Task<bool> Delete(ModuleOfLessons entity)
        {
            if (entity == null || entity.Id == 0) return false;

            try
            {
                _context.Remove(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException)
            {
                return false;
            }
        }
        public async Task<bool> Update(ModuleOfLessons entity)
        {
            if (entity == null) return false;

            try
            {
                _context.Entry(entity).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException)
            {
                return false;
            }
        }
        public async Task<bool> Save()
        {
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException)
            {
                return false;
            }
        }

        public async Task<IEnumerable<ModuleOfLessons>> Select()
        {
            return await _context.ModuleOfLessons.ToListAsync();
        }

        public async Task<ModuleOfLessons?> GetById(int id)
        {
            try
            {
                return await _context.ModuleOfLessons.FirstOrDefaultAsync(c => c.Id == id);
            }
            catch (DbException)
            {
                // Логирование исключения
                return null;
            }
        }
        public async Task<bool> ChangeAvailableModule(ModuleOfLessons entity, bool isAvailable)
        {
            if (entity == null) return false;

            entity.IsAvailable = isAvailable;

            try
            {
                _context.Entry(entity).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException)
            {
                return false;
            }
        }
        public async Task<bool> AddLessonToModule(int moduleId, Lesson entity)
        {
            ModuleOfLessons? module = await _context.ModuleOfLessons
                .Include(c => c.Lessons)
                .FirstOrDefaultAsync(e => e.Id == moduleId);

            if (module == null || entity == null) return false;

            try
            {
                module.Lessons.Add(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException)
            {
                return false;
            }
        }
        public async Task<bool> DeleteLessonFromModule(int moduleId, Lesson entity)
        {
            ModuleOfLessons? module = await _context.ModuleOfLessons
                 .Include(c => c.Lessons)
                 .FirstOrDefaultAsync(e => e.Id == moduleId);

            if (module == null || entity == null) return false;

            try
            {
                module.Lessons.Remove(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException)
            {
                return false;
            }
        }
    }
}
