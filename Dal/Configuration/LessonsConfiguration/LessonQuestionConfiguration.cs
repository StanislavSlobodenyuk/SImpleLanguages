
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Entity.Content.Question;

namespace Dal.Configuration.Lessonsconfiguration
{
    public class LessonQuestionConfiguration : IEntityTypeConfiguration<LessonQuestion>
    {
        public void Configure(EntityTypeBuilder<LessonQuestion> builder)
        {
            builder.ToTable("Lesson_question", "dbo");
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
                .HasConstraintName("FK_LessonQuestions_TestQuestionId_TestQuestion")
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(lq => lq.AudioQuestion)
                .WithMany(e => e.LessonQuestions)
                .HasForeignKey(lq => lq.AudioQuestionId)
                .HasConstraintName("FK_LessonQuestions_AudioQuestionId_AudioQuestion")
                .OnDelete(DeleteBehavior.Restrict);

            builder
               .HasOne(lq => lq.TranslateQuestion)
               .WithMany(e => e.LessonQuestions)
               .HasForeignKey(lq => lq.TranslateQuestionId)
               .HasConstraintName("FK_LessonQuestions_TranslateQuestionId_TranslateQuestion")
               .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(e => e.Lesson)
                .WithMany(e => e.LessonQuestions)
                .HasForeignKey(e => e.LessonId)
                .HasConstraintName("FK_LessonQuestions_LessonId_Lesson")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
