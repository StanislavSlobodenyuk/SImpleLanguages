
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Entity.Content.Lessons;

namespace Dal.Configuration.Lessonsconfiguration
{
    public class CourseModuleConfiguration : IEntityTypeConfiguration<CourseModule>
    {
        public void Configure(EntityTypeBuilder<CourseModule> builder)
        {
            builder.ToTable("Course_Module");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("Id");

            builder.Property(x => x.CourseId)
                .IsRequired()
                .HasColumnName("CourseId");

            builder.Property(x => x.TimeStamp)
                .IsRowVersion()
                .IsConcurrencyToken();

            builder.Property(x => x.Title)
                .IsRequired()
                .HasColumnName("Title");

            builder.Property(x => x.IsAvailable)
                .HasDefaultValue(true)
                .HasColumnName("Is_available");

            builder.Property(x => x.PathToMap)
                .IsRequired()
                .HasColumnName("Path_to_map");

            builder.HasMany(e => e.Lessons)
                .WithOne(e => e.CourseModules)
                .HasForeignKey(e => e.CourseModuleId)
                .IsRequired()
                .HasConstraintName("FK_CourseModules_.ModuleLessonsId_Lessons")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
