
using Domain.Entity.Content.Lessons;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Entity.Content.Question;
using Domain.Entity.Content;

namespace Dal.Configuration
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

            builder.Property(e => e.QuestionText)
                .IsRequired()
                .HasColumnName("Question_Text")
                .HasMaxLength(400);
        }
    }
}
