﻿using Domain.Entity.Content.Lessons;

namespace Dal.Interfaces
{
    public interface ICourseModuleRepository : IBaseRepository<CourseModule>
    {
        Task<IEnumerable<CourseModule>> GetModules(int courseId);
        Task<bool> ChangeAvailableModule(CourseModule module);
    }
}