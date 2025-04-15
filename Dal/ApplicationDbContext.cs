
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Domain.Entity.Content.CourseContent;
using Domain.Entity.Content.Lessons;
using Dal.Configuration;
using Domain.Entity.Content;
using Dal.Configuration.Questions;
using Dal.Configuration.Lessonsconfiguration;
using Dal.Configuration.QuestionConfiguration;
using Domain.Entity.User;
using Dal.Configuration.UserConfiguration;
using Domain.Entity.Content.Question;
using Domain.Entity.Content.Question.Answer;


namespace Dal
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Course> Courses { get; set; }
     
        public DbSet<CourseModule> CourseModules { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Theory> Theories { get; set; }
        public DbSet<LessonQuestion> LessonQuestions { get; set; }

        public DbSet<AnswerOption> AnswerOptions { get; set; }
        public DbSet<RightAnswer> RightAnswers { get; set; }
        public DbSet<AudioQuestion> AudioQuestions { get; set; }
        public DbSet<PictureQuestion> PictureQuestions { get; set; }
        public DbSet<SimpleQuestion> SimpleQuestions { get; set; }
        public DbSet<TextQuestion> TextQuestions { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Ignore<BaseContentCourse>();
            builder.Ignore<BaseQuestion>();

            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new CourseConfiguration());
            builder.ApplyConfiguration(new CourseModuleConfiguration());
            builder.ApplyConfiguration(new LessonConfiguration());
            builder.ApplyConfiguration(new TheoryConfiguration());
            builder.ApplyConfiguration(new LessonQuestionConfiguration());
            builder.ApplyConfiguration(new AnswerOptionConfiguration());
            builder.ApplyConfiguration(new RightAnswerConfiguration());
            builder.ApplyConfiguration(new AudioQuestionConfiguration());
            builder.ApplyConfiguration(new PictureQuestionConfiguration());
            builder.ApplyConfiguration(new SimpleQuestionsConfiguration());
            builder.ApplyConfiguration(new TextQuestionConfiguration());
        }
    }
}
