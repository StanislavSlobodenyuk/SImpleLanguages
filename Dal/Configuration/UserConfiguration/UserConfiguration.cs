
using Domain.Entity.User;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Dal.Configuration.UserConfiguration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(u => u.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(u => u.LastName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(u => u.Birthday)
                .IsRequired();

            builder.Property(u => u.UserIcon)
                .HasMaxLength(255); // Для изображения

            builder.Property(u => u.NativeLanguage)
                .HasMaxLength(50); // Язык

            // Связь с UserSociables
            builder.HasMany(u => u.UserSociables)
                .WithOne()
                .HasForeignKey(us => us.UserId)
                .OnDelete(DeleteBehavior.Cascade);


            // Связь с UserWords
            builder.HasMany(u => u.UserWords)
                .WithOne(uw => uw.User)
                .HasForeignKey(uw => uw.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Связь с UserLessonResults
            builder.HasMany(u => u.LessonResults)
                .WithOne()
                .HasForeignKey(ulr => ulr.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Связь с UserStoryResults
            builder.HasMany(u => u.StoryResults)
                .WithOne()
                .HasForeignKey(usr => usr.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Связь с UserGrammarResults
            builder.HasMany(u => u.GrammarResults)
                .WithOne()
                .HasForeignKey(ugr => ugr.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Связь с UserAchievements
            builder.HasMany(u => u.UserAchievements)
                .WithOne()
                .HasForeignKey(ua => ua.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
