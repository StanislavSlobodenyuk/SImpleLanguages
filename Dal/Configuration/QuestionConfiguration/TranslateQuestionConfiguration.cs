using Domain.Entity.Content.Question;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dal.Configuration.Questions
{
    public class TranslateQuestionConfiguration : IEntityTypeConfiguration<TranslateQuestion>
    {
        public void Configure(EntityTypeBuilder<TranslateQuestion> builder)
        {
            builder.ToTable("Translate_Question", "dbo");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
               .ValueGeneratedOnAdd()
               .HasColumnName("Id");

            builder.Property(e => e.TimeStamp)
                .IsRowVersion()
                .IsConcurrencyToken();

            builder.Property(e => e.SentenceTranslate)
                .HasColumnName("Sentense_translate")
                .IsRequired();

            builder.Property(e => e.Sentence)
                .HasColumnName("Sentense")
                .IsRequired();

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
        }
    }
}
