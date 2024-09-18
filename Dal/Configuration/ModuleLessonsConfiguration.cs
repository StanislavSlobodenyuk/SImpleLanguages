
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Entity.Content.Lessons;

namespace Dal.Configuration
{
    public class ModuleLessonsConfiguration : IEntityTypeConfiguration<ModuleLessons>
    {
        public void Configure(EntityTypeBuilder<ModuleLessons> builder)
        {
            builder.ToTable("ModuleOfLessons");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("Id");
           
            builder.Property(x => x.TimeStamp)
                .IsRowVersion()
                .IsConcurrencyToken();

            builder.Property(x => x.Title)
                .IsRequired()
                .HasColumnName("Title");

            builder.Property(x => x.IsAvailable)
                .HasDefaultValue(false)
                .HasColumnName("Is_Available");

            builder.Property(x => x.PathToMap)
                .IsRequired()
                .HasColumnName("Path_To_Map");

            builder.HasMany(e => e.Lessons)
                .WithOne(e => e.ModuleLessons)
                .HasForeignKey(e => e.ModuleLessonsId)
                .IsRequired()
                .HasConstraintName("FK_ModulesLessons_Lesson_ModuleOfLessons")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
