
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Entity.Content.Question;

namespace Dal.Configuration.Questions
{
    public class AudioQuestionConfiguration : IEntityTypeConfiguration<AudioQuestion>
    {
        public void Configure(EntityTypeBuilder<AudioQuestion> builder)
        {
            builder.ToTable("Audio_Question", "dbo");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd().HasColumnName("Id");
            builder.Property(e => e.AudioPath).IsRequired().HasColumnName("Audio_path");
            builder.Property(e => e.TimeStamp).IsRowVersion().IsConcurrencyToken();
            builder.Property(e => e.QuestionText).IsRequired().HasColumnName("QuestionText").HasMaxLength(400);
            builder.Property(e => e.QType).IsRequired().HasColumnName("QuestionType");
            builder.Property(e => e.AType).IsRequired().HasColumnName("AnswerType");
        }
    }
}
