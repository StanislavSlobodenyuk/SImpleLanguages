using Domain.Entity.Content.Image;
using Domain.Entity.Content.Lessons;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dal.Configuration
{
    public class LessonConfiguration : IEntityTypeConfiguration<Lesson>
    {
        public void Configure(EntityTypeBuilder<Lesson> builder)
        {
            builder.ToTable("Lesson", "dbo");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
               .ValueGeneratedOnAdd()
               .HasColumnName("Id");
            builder.Property(e => e.TimeStamp)
                .IsRowVersion()
                .IsConcurrencyToken();
            builder.Property(e => e.Difficulty)
                .IsRequired();

            builder.HasOne(e => e.Image)
                .WithOne(e => e.Lesson)
                .HasForeignKey<MyImage>(e => e.LessonId)
                .IsRequired()
                .HasConstraintName("FK_ImageLesson_Image_Lesson")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
