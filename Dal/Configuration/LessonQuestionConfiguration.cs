
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
            builder.ToTable("LessonQuestion", "dbo");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
               .ValueGeneratedOnAdd()
               .HasColumnName("Id");
            builder.Property(e => e.TimeStamp)
                .IsRowVersion()
                .IsConcurrencyToken();

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
