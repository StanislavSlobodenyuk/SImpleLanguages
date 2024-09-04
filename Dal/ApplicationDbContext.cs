
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Domain.Entity.Content.Metadata.Course;
using Domain.Entity.Content.Lessons;
using Domain.Entity.Content.Question;
using Domain.Entity.Content.Image;
using Dal.Configuration;
using Domain.Entity.Content;
using System.Reflection.Emit;
using Domain.Entity.Base;

namespace Dal
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        // Metadata
        public DbSet<Course> Courses { get; set; }
        
        // Main content
        // Lessons
        public DbSet<ModuleOfLessons> ModuleOfLessons { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        // Questions
        public DbSet<TestQuestion> TestQuestions { get; set; }
        public DbSet<TestAnswerOption> TestQuestionAnswerOptions { get; set; }
        public DbSet<TestRightAnswer> TestQuestionRightAnswers { get; set; }
        public DbSet<AudioQuestion> AudioQuestions { get; set; } 
        // Image 
        public DbSet<MyImage> MyImages { get; set; }
        public DbSet<QuestionImage> QuestionImages { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Ignore<BaseContent>();
            builder.Ignore<BaseQuestion>();

            // Metadata
            builder.ApplyConfiguration(new CourseConfiguration());

            // Main content
            // Lessons
            builder.ApplyConfiguration(new ModuleOfLessonsConfiguration());
            builder.ApplyConfiguration(new LessonConfiguration());
            // Questions
            builder.ApplyConfiguration(new TestQuestionConfiguration());
            builder.ApplyConfiguration(new TestAnswerOptionConfiguration());
            builder.ApplyConfiguration(new TestRightAnswerConfiguration());
            builder.ApplyConfiguration(new AudioQuestionConfiguration());
            builder.ApplyConfiguration(new LessonQuestionConfiguration());  
            // Image 
            builder.ApplyConfiguration(new MyImageConfiguration());
            builder.ApplyConfiguration(new QuestionImageConfiguration());

            //builder.ApplyConfiguration(new BaseContentConfiguration());
            //builder.ApplyConfiguration(new BaseQuestionConfiguration());
        }
    }
}
