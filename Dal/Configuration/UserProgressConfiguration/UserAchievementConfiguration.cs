using Domain.Entity.User.UserProgress;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Dal.Configuration.UserProgressConfiguration
{
    public class UserAchievementConfiguration : IEntityTypeConfiguration<UserAchievement>
    {
        public void Configure(EntityTypeBuilder<UserAchievement> builder)
        {
            builder.ToTable("UserAchievement", "dbo");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("Id");

            builder.Property(x => x.TimeStamp)
                .IsRowVersion()
                .IsConcurrencyToken();

            builder.Property(x => x.DateEarned)
                .HasColumnName("DateEarned")
                .IsRequired();

            builder.Property(x => x.IsEarned)
                .HasColumnName("IsEarned")
                .IsRequired();

            // 🔗 Связь с Achievement
            builder.HasOne(x => x.Achievement)
                .WithMany(a => a.UserAchievements)
                .HasForeignKey(x => x.AchievementId)
                .OnDelete(DeleteBehavior.Cascade);

            // 🔗 Связь с User
            builder.HasOne(x => x.User)
                .WithMany(u => u.UserAchievements)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
