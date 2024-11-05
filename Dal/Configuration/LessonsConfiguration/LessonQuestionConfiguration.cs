
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Entity.Content.Lessons;

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

            builder.Property(e => e.TimeStamp).IsRowVersion().IsConcurrencyToken();
            builder.Property(e => e.AudioQuestionId).IsRequired(false);
            builder.Property(e => e.TestQuestionId).IsRequired(false);
            builder.Property(e => e.TextQuestionId).IsRequired(false);
            builder.Property(e => e.ImageQuestionId).IsRequired(false);



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
                   .HasOne(lq => lq.TextQuestion)
                   .WithMany(e => e.LessonQuestions)
                   .HasForeignKey(lq => lq.TextQuestionId)
                   .HasConstraintName("FK_LessonQuestions_TextQuestionId_TextQuestion")
                   .OnDelete(DeleteBehavior.Restrict);
                builder
                 .HasOne(lq => lq.ImageQuestion)
                 .WithMany(e => e.LessonQuestions)
                 .HasForeignKey(lq => lq.ImageQuestionId)
                 .HasConstraintName("FK_LessonQuestions_ImageQuestionId_ImageQuestion")
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
