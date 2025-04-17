
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
using Domain.Entity.User.UserProgress.TaskResult;
using Domain.Entity.Content.GrammarContent;
using Domain.Entity.Content.StoryContent;
using Domain.Entity.User.UserProfile;
using Domain.Entity.Content.DictionaryContent;
using Domain.Entity.User.UserProgress;
using Dal.Configuration.GrammarConfiguration;
using Dal.Configuration.StoryConfiguration;
using Dal.Configuration.UserProfile;
using Dal.Configuration.UserProgressConfiguration;
using Dal.Configuration.Dictionary;
using Domain.Entity.Content.Achievments;


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
        public DbSet<Grammar> Grammars { get; set; }
        public DbSet<Story> Stories { get; set; }
        public DbSet<MyDictionary> Dictionaries { get; set; }
        public DbSet<Achievement> Achievements { get; set; }
        public DbSet<UserAchievement> AchievementUsers { get; set; }

        public DbSet<AnswerOption> AnswerOptions { get; set; }
        public DbSet<RightAnswer> RightAnswers { get; set; }
        public DbSet<AudioQuestion> AudioQuestions { get; set; }
        public DbSet<PictureQuestion> PictureQuestions { get; set; }
        public DbSet<SimpleQuestion> SimpleQuestions { get; set; }
        public DbSet<TextQuestion> TextQuestions { get; set; }

        public DbSet<UserWord> UserWords { get; set; }
        public DbSet<UserAchievement> UserAchievements { get; set; }
        public DbSet<UserGrammarResult> UserGrammarResults { get; set; }
        public DbSet<UserStoryResult> UserStoryResults { get; set; }
        public DbSet<UserLessonResult> UserLessonResults { get; set; }

        public DbSet<UserSociable> UserSociables { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Ignore<BaseContentCourse>();
            builder.Ignore<BaseQuestion>();
            builder.Ignore<UserTaskResultBase>();

            builder.ApplyConfiguration(new UserConfiguration());

            builder.ApplyConfiguration(new CourseConfiguration());
            builder.ApplyConfiguration(new CourseModuleConfiguration());
            builder.ApplyConfiguration(new LessonConfiguration());
            builder.ApplyConfiguration(new TheoryConfiguration());
            builder.ApplyConfiguration(new GrammarConfiguration());
            builder.ApplyConfiguration(new StoryConfiguration());
            
            builder.ApplyConfiguration(new DictionaryConfiguration());
            builder.ApplyConfiguration(new CourseWordConfiguration());

            builder.ApplyConfiguration(new LessonQuestionConfiguration());
            builder.ApplyConfiguration(new AnswerOptionConfiguration());
            builder.ApplyConfiguration(new RightAnswerConfiguration());

            builder.ApplyConfiguration(new AudioQuestionConfiguration());
            builder.ApplyConfiguration(new PictureQuestionConfiguration());
            builder.ApplyConfiguration(new SimpleQuestionsConfiguration());
            builder.ApplyConfiguration(new TextQuestionConfiguration());

            builder.ApplyConfiguration(new UserGrammarResultConfiguration());
            builder.ApplyConfiguration(new UserStoryResultConfiguration());
            builder.ApplyConfiguration(new UserLessonResultConfiguration());
            builder.ApplyConfiguration(new UserWordConfiguration());

            builder.ApplyConfiguration(new AchievementConfiguration());
            builder.ApplyConfiguration(new UserAchievementConfiguration());

            builder.ApplyConfiguration(new SociableConfiguration());
        }
    }
}
