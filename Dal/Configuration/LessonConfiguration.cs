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

            builder.Property(e => e.Title)
                .IsRequired()
                .HasColumnName("Title")
                .HasMaxLength(200);

            builder.Property(e => e.IsAvailable)
                .HasDefaultValue(true)
                .HasColumnName("Is_Available")
                .IsRequired();

            builder.Property(e => e.IconPath)
                .HasColumnName("Icon_Path")
                .IsRequired();

            builder.HasMany(e => e.LectureBlocks)
                .WithOne(e => e.lesson)
                .HasForeignKey(e => e.LessonId)
                .HasConstraintName("FK_LessonLectureBlock_Lesson_LectureBlock")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
