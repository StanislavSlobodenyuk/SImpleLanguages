using Domain.Entity.Content.Question;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Dal.Configuration.Questions
{
    public class TestAnswerOptionConfiguration : IEntityTypeConfiguration<TestAnswerOption>
    {
        public void Configure(EntityTypeBuilder<TestAnswerOption> builder)
        {
            builder.ToTable("Test_answer_option", "dbo");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
               .ValueGeneratedOnAdd()
               .HasColumnName("Id");

            builder.Property(e => e.TimeStamp)
                .IsRowVersion()
                .IsConcurrencyToken();

            builder.Property(e => e.OptionText)
                .IsRequired()
                .HasColumnName("Answer_option")
                .HasMaxLength(500);
        }
    }
}
