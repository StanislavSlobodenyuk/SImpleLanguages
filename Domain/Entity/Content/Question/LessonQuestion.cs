﻿
using Domain.Entity.Base;
using Domain.Entity.Content.Lessons;

namespace Domain.Entity.Content.Question
{
    public class LessonQuestion : BaseEntity
    {
        public int LessonId { get; set; }
        public Lesson? Lesson { get; set; }

        public int QuestionId { get; set; }
        public TestQuestion? Question { get; set; }
    }
}