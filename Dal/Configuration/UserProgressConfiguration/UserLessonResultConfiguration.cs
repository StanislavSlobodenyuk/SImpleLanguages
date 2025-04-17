using Domain.Entity.User.UserProgress.TaskResult;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Dal.Configuration.UserProgressConfiguration
{
    public class UserLessonResultConfiguration : IEntityTypeConfiguration<UserLessonResult>
    {
        public void Configure(EntityTypeBuilder<UserLessonResult> builder)
        {
            builder.ToTable("UserLessonResult", "dbo");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("Id");

            builder.Property(x => x.TimeStamp)
                .IsRowVersion()
                .IsConcurrencyToken();

            builder.Property(x => x.LessonId)
                .HasColumnName("LessonId")
                .IsRequired();

            // 🔗 Связь с Lesson
            builder.HasOne(x => x.Lesson)
                .WithMany(e => e.UserLessonsResult)
                .HasForeignKey(x => x.LessonId)
                .OnDelete(DeleteBehavior.Cascade);

            // 🔗 Связь с User
            builder.HasOne(x => x.User)
                .WithMany(u => u.LessonResults)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
