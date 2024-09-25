
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Entity.Content.Question;

namespace Dal.Configuration
{
    public class AudioQuestionConfiguration : IEntityTypeConfiguration<AudioQuestion>
    {
        public void Configure(EntityTypeBuilder<AudioQuestion> builder)
        {
            builder.ToTable(" Audio_Question", "dbo");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
               .ValueGeneratedOnAdd()
               .HasColumnName("Id");
            
            builder.Property(e => e.TimeStamp)
                .IsRowVersion()
                .IsConcurrencyToken();

            builder.Property(e => e.AudioUrl)
                .HasMaxLength(300)
                .HasColumnName("Audio_url")
                .IsRequired();

            builder.Property(e => e.RightAnswer)
                .HasMaxLength(300)
                .IsRequired();
            
            builder.Property(e => e.QuestionText)
                .IsRequired()
                .HasColumnName("Question_text")
                .HasMaxLength(400);
        }
    }
}
