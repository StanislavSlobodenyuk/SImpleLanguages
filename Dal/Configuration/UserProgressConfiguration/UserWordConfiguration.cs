
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Entity.User.UserProgress;

namespace Dal.Configuration.UserProgressConfiguration
{
    public  class UserWordConfiguration : IEntityTypeConfiguration<UserWord>
    {
        public void Configure(EntityTypeBuilder<UserWord> builder)
        {
            builder.ToTable("UserWord", "dbo");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("Id");

            builder.Property(x => x.TimeStamp)
                .IsRowVersion()
                .IsConcurrencyToken();

            builder.Property(x => x.DateAdded)
                .HasColumnName("DateAdded")
                .IsRequired();

            builder.Property(x => x.IsLearned)
                .HasColumnName("IsLearned")
                .IsRequired();

            builder.Property(x => x.RepetitionCount)
                .HasColumnName("RepetitionCount")
                .IsRequired();

            builder.Property(x => x.LastReviewed)
                .HasColumnName("LastReviewed");

            builder.Property(x => x.UserId)
                .HasColumnName("UserId")
                .IsRequired();

            builder.Property(x => x.DictionaryId)
                .HasColumnName("DictionaryId")
                .IsRequired();

            // 🔗 Связь с User
            builder.HasOne(x => x.User)
                .WithMany(u => u.UserWords)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // 🔗 Связь с Dictionary
            builder.HasOne(x => x.Dictionary)
                .WithMany(d => d.UserWords)
                .HasForeignKey(x => x.DictionaryId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
