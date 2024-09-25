
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

            builder.Property(e => e.QuestionId)
                .HasColumnName("TestQuestionId")
                .IsRequired();

            builder.Property(e => e.TypeQuestion)
                .HasColumnName("QuestionType")
                .IsRequired();

            builder
               .HasOne(e => e.Question)
               .WithMany(e => e.LessonQuestions)
               .HasForeignKey(e => e.QuestionId)
               .HasConstraintName("FK_LessonQuestions_QuestionId")
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
