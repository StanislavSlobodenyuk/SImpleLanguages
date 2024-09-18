using Domain.Entity.Content.Image;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dal.Configuration
{
    public class LectureBlockImageConfiguration : IEntityTypeConfiguration<LectureImage>
    {
        public void Configure(EntityTypeBuilder<LectureImage> builder)
        {
            builder.ToTable("Lecture_Image", "dbo");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
               .ValueGeneratedOnAdd()
               .HasColumnName("Id");
            
            builder.Property(e => e.TimeStamp)
                .IsRowVersion()
                .IsConcurrencyToken();

            builder
               .HasOne(e => e.Lecture)
               .WithMany(e => e.LectureImages)
               .HasForeignKey(e => e.LectureId)
               .HasConstraintName("FK_LecturesImages_LectureId")
               .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(e => e.Image)
                .WithMany(e => e.LectureImages)
                .HasForeignKey(e => e.ImageId)
                .HasConstraintName("FK_LecturesImages_ImageId")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
