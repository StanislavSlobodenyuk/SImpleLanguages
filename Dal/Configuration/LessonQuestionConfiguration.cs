
using Domain.Entity.Content.Lessons;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Entity.Content.Question;

namespace Dal.Configuration
{
    public class LessonQuestionConfiguration : IEntityTypeConfiguration<LessonQuestion>
    {
        public void Configure(EntityTypeBuilder<LessonQuestion> builder)
        {
            builder.ToTable("Lesson_Question", "dbo");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
               .ValueGeneratedOnAdd()
               .HasColumnName("Id");
            
            builder.Property(e => e.TimeStamp)
                .IsRowVersion()
                .IsConcurrencyToken();

            builder
                .HasOne(lq => lq.TestQuestion)
                .WithMany(e => e.LessonQuestions) 
                .HasForeignKey(lq => lq.TestQuestionId)
                .HasConstraintName("FK_LessonTestQuestions_LessonQuestions")
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(lq => lq.AudioQuestion)
                .WithMany(e => e.LessonQuestions) 
                .HasForeignKey(lq => lq.AudioQuestionId)
                .HasConstraintName("FK_LessonAudioQuestions_LessonQuestions")
                .OnDelete(DeleteBehavior.Restrict);

            builder
               .HasOne(lq => lq.TranslateQuestion)
               .WithMany(e => e.LessonQuestions)
               .HasForeignKey(lq => lq.TestQuestionId)
               .HasConstraintName("FK_TranslateQuestion_LessonQuestions")
               .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(e => e.Lesson)
                .WithMany(e => e.LessonQuestions)
                .HasForeignKey(e => e.LessonId)
                .HasConstraintName("FK_LessonQuestions_LessonId")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
