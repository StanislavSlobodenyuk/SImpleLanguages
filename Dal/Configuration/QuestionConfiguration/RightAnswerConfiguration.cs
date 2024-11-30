using Domain.Entity.Content.Question.Answer;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Dal.Configuration.QuestionConfiguration
{
    public class RightAnswerConfiguration : IEntityTypeConfiguration<RightAnswer>
    {
        public void Configure(EntityTypeBuilder<RightAnswer> builder)
        {
            builder.ToTable("RightAnswers", "dbo");

            builder.HasKey(r => r.Id); 

            builder.Property(r => r.Answer).IsRequired() .HasMaxLength(255);
            builder.Property(e => e.AudioQuestionId).IsRequired(false);
            builder.Property(e => e.SimpleQuestionId).IsRequired(false);
            builder.Property(e => e.TextQuestionId).IsRequired(false);
            builder.Property(e => e.ImageQuestionId).IsRequired(false);

            builder.HasOne(r => r.SimpleQuestion)
                .WithMany(q => q.RightAnswers) 
                .HasForeignKey(r => r.SimpleQuestionId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(r => r.AudioQuestion)
              .WithMany(q => q.RightAnswers)
              .HasForeignKey(r => r.AudioQuestionId)
              .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(r => r.TextQuestion)
              .WithMany(q => q.RightAnswers)
              .HasForeignKey(r => r.TextQuestionId)
              .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(r => r.ImageQuestion)
              .WithMany(q => q.RightAnswers)
              .HasForeignKey(r => r.ImageQuestionId)
              .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
