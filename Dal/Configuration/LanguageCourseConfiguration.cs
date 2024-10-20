using Domain.Entity.Content.Metadata.Course;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dal.Configuration
{
    public class LanguageCourseConfiguration : IEntityTypeConfiguration<LanguageCourse>
    {
        public void Configure(EntityTypeBuilder<LanguageCourse> builder)
        {
            builder.ToTable("Course", "dbo");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
               .ValueGeneratedOnAdd()
               .HasColumnName("Id");

            builder.Property(e => e.TimeStamp)
                .IsRowVersion()
                .IsConcurrencyToken();

            builder.Property(e => e.Name)
                .IsRequired()
                .HasColumnName("Name")
                .HasMaxLength(255);

            builder.Property(e => e.Difficult)
               .IsRequired()
               .HasColumnName("Difficult");

            builder.Property(e => e.Description)
                .HasDefaultValue("Опис ще не написаний")
                .HasColumnName("Description")
                .HasMaxLength(1000);

            builder.Property(e => e.Language)
                .HasColumnName("Language")
                .IsRequired();

            builder.Property(e => e.IconPath)
                .IsRequired()
                .HasColumnName("Icon_path");

            builder.Property(e => e.Progres)
                .HasColumnName("Last_save_result")
                .HasDefaultValue(0);

            builder.HasMany(e => e.CourseModules)
                .WithOne(e => e.LanguageCourse)
                .HasForeignKey(e => e.LanguageCourseId)
                .IsRequired()
                .HasConstraintName("FK_LanguegeCourse_LanguageCourseId_CourseModules")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
