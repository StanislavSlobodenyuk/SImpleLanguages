﻿
using Dal.Interfaces;
using Domain.Entity.Content.Lessons;
using Domain.Entity.Content.Metadata.Course;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace Dal.Repositories
{
    public class ModuleLessonsRepositories : IModuleLessonsRepository
    {
        private readonly ApplicationDbContext _context;
        public ModuleLessonsRepositories(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Create(ModuleLessons entity)
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
        public async Task<bool> Delete(ModuleLessons entity)
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
        public async Task<ModuleLessons?> Update(ModuleLessons entity)
        {
            if (entity == null) return null;

            try
            {
                _context.Entry(entity).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return await _context.ModuleOfLessons.FindAsync(entity.Id);
            }
            catch (DbUpdateException)
            {
                return null;
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

        public async Task<IEnumerable<ModuleLessons>> Select()
        {
            return await _context.ModuleOfLessons.ToListAsync();
        }

        public async Task<ModuleLessons?> GetById(int id)
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
        public async Task<bool> ChangeAvailableModule(ModuleLessons entity, bool isAvailable)
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
            ModuleLessons? module = await _context.ModuleOfLessons
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
            ModuleLessons? module = await _context.ModuleOfLessons
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