using Domain.Entity.User.UserProgress.TaskResult;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dal.Configuration.UserProgressConfiguration
{
    public class UserStoryResultConfiguration : IEntityTypeConfiguration<UserStoryResult>
    {
        public void Configure(EntityTypeBuilder<UserStoryResult> builder)
        {
            builder.ToTable("UserStoryResult", "dbo");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("Id");

            builder.Property(x => x.TimeStamp)
                .IsRowVersion()
                .IsConcurrencyToken();

            builder.Property(x => x.StoryId)
                .HasColumnName("StoryId")
                .IsRequired();

            // 🔗 Связь с Story
            builder.HasOne(x => x.Story)
                .WithMany(e => e.StoryResults)
                .HasForeignKey(x => x.StoryId)
                .OnDelete(DeleteBehavior.Cascade);

            // 🔗 Связь с User
            builder.HasOne(x => x.User)
                .WithMany(u => u.StoryResults)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
