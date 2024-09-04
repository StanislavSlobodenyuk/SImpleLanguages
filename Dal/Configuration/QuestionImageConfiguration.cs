using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Entity.Content.Image;

namespace Dal.Configuration
{
    public class QuestionImageConfiguration : IEntityTypeConfiguration<QuestionImage>
    {
        public void Configure(EntityTypeBuilder<QuestionImage> builder)
        {
            builder.ToTable("QuestionImage", "dbo");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
               .ValueGeneratedOnAdd()
               .HasColumnName("Id");
            builder.Property(e => e.TimeStamp)
                .IsRowVersion()
                .IsConcurrencyToken();

            builder
               .HasOne(e => e.Question)
               .WithMany(e => e.QuestionImages)
               .HasForeignKey(e => e.QuestionId)
               .HasConstraintName("FK_QuestionImages_QuestionId")
               .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(e => e.Image)
                .WithMany(e => e.QuestionImages)
                .HasForeignKey(e => e.ImageId)
                .HasConstraintName("FK_QuestionImages_ImageId")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
