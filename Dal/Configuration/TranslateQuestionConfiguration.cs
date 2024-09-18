
using Domain.Entity.Content.Question;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dal.Configuration
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
                .HasColumnName("Sentense_Translate")
                .IsRequired();

            builder.Property(e => e.Sentence)
                .HasColumnName("Sentense")
                .IsRequired();

            builder.Property(e => e.QuestionText)
               .IsRequired()
               .HasColumnName("Question_Text")
               .HasMaxLength(400);

            builder.Property(e => e.Type)
                .IsRequired();
        }
    }
}
