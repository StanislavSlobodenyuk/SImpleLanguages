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
                .HasColumnName("Name");

            builder.Property(e => e.Description)
                .HasDefaultValue("Опис ще не написаний")
                .HasColumnName("Description");

            builder.Property(e => e.Language)
                .HasColumnName("Language")
                .IsRequired();

            builder.Property(e => e.Difficult)
                .HasColumnName("Difficult")
                .IsRequired();   
            
            builder.Property(e => e.IconPath)
                .IsRequired()
                .HasColumnName("Icon_Path");

            builder.Property(e => e.Progres)
                .HasColumnName("Last_Save_Result")
                .HasDefaultValue(0);

            builder.HasMany(e => e.ModulesLessons)
                .WithOne(e=> e.LanguageCourse)
                .HasForeignKey(e => e.LanguageCourseId)
                .IsRequired()
                .HasConstraintName("FK_CourseModules_Course_ModuleOfLessons")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
