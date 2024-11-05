
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Domain.Entity.Content.CourseContent;
using Domain.Entity.Content.Lessons;
using Domain.Entity.Content.Question;
using Domain.Entity.Content.Image;
using Dal.Configuration;
using Domain.Entity.Content;
using Dal.Configuration.Questions;
using Dal.Configuration.ImageConfiguration;
using Dal.Configuration.Lessonsconfiguration;
using Dal.Configuration.QuestionConfiguration;
using Domain.Entity.Content.Question.Answer;


namespace Dal
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        // Metadata
        public DbSet<Course> Courses { get; set; }
        
        // Main content
        // Lessons
        public DbSet<CourseModule> CourseModules { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Theory> Theories { get; set; }
        public DbSet<LessonQuestion> LessonQuestions { get; set; }
        // Questions
        public DbSet<AnswerOption> AnswerOptions { get; set; }
        public DbSet<RightAnswer> RightAnswers { get; set; }
        public DbSet<AudioQuestion> AudioQuestions { get; set; }
        public DbSet<ImageQuestion> ImageQuestions { get; set; }
        public DbSet<TestQuestion> TestQuestions { get; set; }
        public DbSet<TextQuestion> TextQuestions { get; set; }
        // Image 
        public DbSet<MyImage> MyImages { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Ignore<BaseContentCourse>();
            builder.Ignore<BaseQuestion>();

            // Metadata
            builder.ApplyConfiguration(new CourseConfiguration());

            // Main content
            // Lessons
            builder.ApplyConfiguration(new CourseModuleConfiguration());
            builder.ApplyConfiguration(new LessonConfiguration());
            builder.ApplyConfiguration(new TheoryConfiguration());
            builder.ApplyConfiguration(new LessonQuestionConfiguration());
            // Questions
            builder.ApplyConfiguration(new AnswerOptionConfiguration());
            builder.ApplyConfiguration(new RightAnswerConfiguration());
            builder.ApplyConfiguration(new AudioQuestionConfiguration());
            builder.ApplyConfiguration(new ImageQuestionConfiguration());
            builder.ApplyConfiguration(new TestQuestionConfiguration());
            builder.ApplyConfiguration(new TextQuestionConfiguration());
            // Image 
            builder.ApplyConfiguration(new MyImageConfiguration());
        }
    }
}
