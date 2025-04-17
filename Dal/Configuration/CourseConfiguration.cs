using Domain.Entity.Content.CourseContent;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dal.Configuration
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.ToTable("Course", "dbo");
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
                .HasMaxLength(255);

            builder.Property(e => e.Description)
                .HasDefaultValue("Опис ще не написаний")
                .HasColumnName("Description")
                .HasMaxLength(1000);

            builder.Property(e => e.Level)
                .IsRequired()
                .HasColumnName("Level");

            builder.Property(e => e.Language)
                .HasColumnName("Language")
                .IsRequired();

            builder.Property(e => e.Cost)
                .HasColumnName("Cost")
                .HasColumnType("decimal(18, 2)")
                .HasDefaultValue(0)
                .IsRequired();

            builder.Property(e => e.ImgPath)
                .HasColumnName("Icon_path")
                .IsRequired();

            // Связь с CourseModules
            builder.HasMany(e => e.CourseModules)
                .WithOne(e => e.Course)
                .HasForeignKey(e => e.CourseId)
                .IsRequired()
                .HasConstraintName("Course_CourseId_CourseModules")
                .OnDelete(DeleteBehavior.Cascade);

            // Связь с Grammars
            builder.HasMany(e => e.Grammars)
                .WithOne()
                .HasForeignKey(g => g.CourseId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            // Связь с Stories
            builder.HasMany(e => e.Stories)
                .WithOne()
                .HasForeignKey(s => s.CourseId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            // Связь с CourseWords
            builder.HasMany(e => e.CourseWords)
                .WithOne()
                .HasForeignKey(cw => cw.CourseId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
