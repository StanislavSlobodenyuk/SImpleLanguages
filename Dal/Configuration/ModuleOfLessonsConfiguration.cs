
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Entity.Content.Lessons;
using Domain.Entity.Content;

namespace Dal.Configuration
{
    public class ModuleOfLessonsConfiguration : IEntityTypeConfiguration<ModuleOfLessons>
    {
        public void Configure(EntityTypeBuilder<ModuleOfLessons> builder)
        {
            builder.ToTable("ModuleOfLessons"); // Указываем имя таблицы

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("Id");

            builder.Property(x => x.Title)
                .IsRequired()
                .HasColumnName("Title");

            builder.Property(x => x.LanguageCourseId)
                .IsRequired()
                .HasColumnName("LanguageCourseId");

            builder.Property(x => x.Description)
                .HasMaxLength(220)
                .HasColumnName("Description");

            builder.Property(x => x.TimeStamp)
                .IsRowVersion()
                .IsConcurrencyToken();

            builder.HasMany(e => e.Lessons)
                .WithOne(e => e.ModuleOfLessons)
                .HasForeignKey(e => e.ModuleOfLessonsId)
                .IsRequired()
                .HasConstraintName("FK_ModulesLessons_Lesson_ModuleOfLessons")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
