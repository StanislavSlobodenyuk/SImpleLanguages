
using Domain.Entity.Content.Lessons;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Entity.Content.Question;
using Domain.Entity.Content;

namespace Dal.Configuration.Questions
{
    public class TestQuestionConfiguration : IEntityTypeConfiguration<TestQuestion>
    {
        public void Configure(EntityTypeBuilder<TestQuestion> builder)
        {
            builder.ToTable("Test_Question", "dbo");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
               .ValueGeneratedOnAdd()
               .HasColumnName("Id");

            builder.Property(e => e.TimeStamp)
                .IsRowVersion()
                .IsConcurrencyToken();

            builder.Property(e => e.Text)
                .IsRequired()
                .HasColumnName("Text")
                .HasMaxLength(400);

            builder.Property(e => e.RightAnswer)
                .IsRequired()
                .HasColumnName("Right_answer");

            builder.Property(e => e.Type)
                .IsRequired()
                .HasColumnName("Type");

            builder
                .HasMany(e => e.AnswerOptions)
                .WithOne(e => e.TestQuestion)
                .HasForeignKey(e => e.TestQuestionId)
                .HasConstraintName("FK_TestQuestion_TestQuestionId_AnswerOptions")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
