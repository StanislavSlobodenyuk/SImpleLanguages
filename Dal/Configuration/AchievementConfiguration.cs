using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Entity.Content.Achievments;

namespace Dal.Configuration
{
    public class AchievementConfiguration : IEntityTypeConfiguration<Achievement>
    {
        public void Configure(EntityTypeBuilder<Achievement> builder)
        {
            builder.ToTable("Achievement", "dbo");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("Id");

            builder.Property(e => e.TimeStamp)
                .IsRowVersion()
                .IsConcurrencyToken();

            builder.Property(e => e.Title)
                .HasColumnName("Title")
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(e => e.Description)
                .HasColumnName("Description")
                .HasMaxLength(300)
                .IsRequired();

            builder.Property(e => e.IconPath)
                .HasColumnName("IconPath")
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(e => e.IsCourseRelated)
                .HasColumnName("IsCourseRelated")
                .IsRequired();

            builder.Property(e => e.TargetValue)
                .HasColumnName("Target_Value")
                .IsRequired();

            // Связь с UserAchievements
            builder.HasMany(e => e.UserAchievements)
                .WithOne()
                .HasForeignKey(ua => ua.AchievementId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
