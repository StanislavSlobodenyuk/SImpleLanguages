﻿using Domain.Entity.Content.Question;
using Domain.Entity.Content.Lessons;

namespace Dal.Interfaces.LearnContent
{
    public interface ILessonRepository : IBaseRepository<Lesson>
    {
        Task<IEnumerable<Lesson>> GetLessons(int moduleId);
        Task<Lesson?> ChangeAvailableLesson(Lesson lesson);
    }
}
