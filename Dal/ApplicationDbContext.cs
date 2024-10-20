
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Domain.Entity.Content.Metadata.Course;
using Domain.Entity.Content.Lessons;
using Domain.Entity.Content.Question;
using Domain.Entity.Content.Image;
using Dal.Configuration;
using Domain.Entity.Content;
using Dal.Configuration.Questions;
using Dal.Configuration.ImageConfiguration;
using Dal.Configuration.Lessonsconfiguration;


namespace Dal
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        // Metadata
        public DbSet<LanguageCourse> LanguageCourses { get; set; }
        
        // Main content
        // Lessons
        public DbSet<CourseModule> CourseModules { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<LectureBlock> LectureBlocks { get; set; }
        // Questions
        public DbSet<TestQuestion> TestQuestions { get; set; }
        public DbSet<TestAnswerOption> TestQuestionAnswerOptions { get; set; }
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
            builder.ApplyConfiguration(new CourseModuleConfiguration());
            builder.ApplyConfiguration(new LessonConfiguration());
            builder.ApplyConfiguration(new LectureBlockConfiguration());
            builder.ApplyConfiguration(new TranslateQuestionConfiguration());
            builder.ApplyConfiguration(new LessonQuestionConfiguration());
            // Questions
            builder.ApplyConfiguration(new TestQuestionConfiguration());
            builder.ApplyConfiguration(new TestAnswerOptionConfiguration());
            builder.ApplyConfiguration(new AudioQuestionConfiguration());
            // Image 
            builder.ApplyConfiguration(new MyImageConfiguration());
            builder.ApplyConfiguration(new QuestionImageConfiguration());
            builder.ApplyConfiguration(new LectureBlockImageConfiguration());

        }
    }
}
