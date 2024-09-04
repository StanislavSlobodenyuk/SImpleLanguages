using Domain.Entity.Content.Metadata.Course;
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
            builder.Property(e => e.LanguageName)
                .IsRequired()
                .HasColumnName("LanguageName");
            builder.Property(e => e.Code)
                .IsRequired()
                .HasColumnName("Code");
            builder.Property(e => e.Icon)
                .IsRequired()
                .HasColumnName("IconPath");

            builder.HasMany(e => e.ModulesOfLessons)
                .WithOne(e=> e.LanguageCourse)
                .HasForeignKey(e => e.LanguageCourseId)
                .IsRequired()
                .HasConstraintName("FK_CourseModules_Course_ModuleOfLessons")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
