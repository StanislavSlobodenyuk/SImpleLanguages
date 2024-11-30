using Domain.Entity.Content.Question.Answer;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Dal.Configuration.QuestionConfiguration
{
    public class AnswerOptionConfiguration : IEntityTypeConfiguration<AnswerOption>
    {
        public void Configure(EntityTypeBuilder<AnswerOption> builder)
        {
            builder.ToTable("AnswerOption", "dbo");

            builder.HasKey(a => a.Id); 

            builder.Property(a => a.Option).HasColumnName("Option").IsRequired().HasMaxLength(255);
            builder.Property(e => e.AudioQuestionId).IsRequired(false);
            builder.Property(e => e.SimpleQuestionId).IsRequired(false);
            builder.Property(e => e.TextQuestionId).IsRequired(false);
            builder.Property(e => e.ImageQuestionId).IsRequired(false);

            builder.HasOne(a => a.SimpleQuestion)
                .WithMany(q => q.AnswerOptions) 
                .HasForeignKey(a => a.SimpleQuestionId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(a => a.AudioQuestion)
              .WithMany(q => q.AnswerOptions)
              .HasForeignKey(a => a.AudioQuestionId)
              .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(a => a.TextQuestion)
              .WithMany(q => q.AnswerOptions)
              .HasForeignKey(a => a.TextQuestionId)
              .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(a => a.ImageQuestion)
              .WithMany(q => q.AnswerOptions)
              .HasForeignKey(a => a.ImageQuestionId)
              .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
