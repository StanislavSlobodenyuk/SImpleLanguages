using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Entity.Content.Image;

namespace Dal.Configuration.ImageConfiguration
{
    public class QuestionImageConfiguration : IEntityTypeConfiguration<QuestionImage>
    {
        public void Configure(EntityTypeBuilder<QuestionImage> builder)
        {
            builder.ToTable("Question_Image", "dbo");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
               .ValueGeneratedOnAdd()
               .HasColumnName("Id");

            builder.Property(e => e.TimeStamp)
                .IsRowVersion()
                .IsConcurrencyToken();

            builder
               .HasOne(e => e.TestQuestion)
               .WithMany(e => e.QuestionImages)
               .HasForeignKey(e => e.TestQuestionId)
               .HasConstraintName("FK_QuestionImages_TestQuestionId_TestQuestion")
               .OnDelete(DeleteBehavior.Restrict);

            builder
               .HasOne(e => e.AudioQuestion)
               .WithMany(e => e.QuestionImages)
               .HasForeignKey(e => e.AudioQuestionId)
               .HasConstraintName("FK_QuestionImages_AudioQuestionId_AudioQuestion")
               .OnDelete(DeleteBehavior.Restrict);

            builder
               .HasOne(e => e.TranslateQuestion)
               .WithMany(e => e.QuestionImages)
               .HasForeignKey(e => e.TranslateQuestionId)
               .HasConstraintName("FK_QuestionImages_TranslateQuestionId_TranslateQuestion")
               .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(e => e.Image)
                .WithMany(e => e.QuestionImages)
                .HasForeignKey(e => e.ImageId)
                .HasConstraintName("FK_QuestionImages_ImageId_Image")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
