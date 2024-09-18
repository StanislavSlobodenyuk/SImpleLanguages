
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
        public DbSet<LanguageCourse> LanguageCourses { get; set; }
        
        // Main content
        // Lessons
        public DbSet<ModuleLessons> ModuleLessons { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<LectureBlock> Lectures { get; set; }
        // Questions
        public DbSet<TestQuestion> TestQuestions { get; set; }
        public DbSet<TestAnswerOption> TestQuestionAnswerOptions { get; set; }
        public DbSet<TestRightAnswer> TestQuestionRightAnswers { get; set; }
        public DbSet<AudioQuestion> AudioQuestions { get; set; } 
        public DbSet<TranslateQuestion> TranslateQuestions { get; set; }
        public DbSet<LessonQuestion> LessonQuestions { get; set; }
        // Image 
        public DbSet<MyImage> MyImages { get; set; }
        public DbSet<QuestionImage> QuestionImages { get; set; }
        public DbSet<LectureImage> LectureBlockImages { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Ignore<BaseContent>();
            builder.Ignore<BaseQuestion>();

            // Metadata
            builder.ApplyConfiguration(new LanguageCourseConfiguration());

            // Main content
            // Lessons
            builder.ApplyConfiguration(new ModuleLessonsConfiguration());
            builder.ApplyConfiguration(new LessonConfiguration());
            builder.ApplyConfiguration(new LectureBlockConfiguration());
            // Questions
            builder.ApplyConfiguration(new TestQuestionConfiguration());
            builder.ApplyConfiguration(new TestAnswerOptionConfiguration());
            builder.ApplyConfiguration(new TestRightAnswerConfiguration());
            builder.ApplyConfiguration(new AudioQuestionConfiguration());
            builder.ApplyConfiguration(new TranslateQuestionConfiguration());
            builder.ApplyConfiguration(new LessonQuestionConfiguration());  
            // Image 
            builder.ApplyConfiguration(new MyImageConfiguration());
            builder.ApplyConfiguration(new QuestionImageConfiguration());
            builder.ApplyConfiguration(new LectureBlockImageConfiguration());

        }
    }
}
