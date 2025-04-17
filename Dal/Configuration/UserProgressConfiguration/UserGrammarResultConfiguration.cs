using Domain.Entity.User.UserProgress.TaskResult;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Dal.Configuration.UserProgressConfiguration
{
    public class UserGrammarResultConfiguration : IEntityTypeConfiguration<UserGrammarResult>
    {
        public void Configure(EntityTypeBuilder<UserGrammarResult> builder)
        {
            builder.ToTable("UserGrammarResult", "dbo");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("Id");

            builder.Property(x => x.TimeStamp)
                .IsRowVersion()
                .IsConcurrencyToken();

            builder.Property(x => x.GrammarId)
                .HasColumnName("GrammarId")
                .IsRequired();

            // 🔗 Связь с Grammar
            builder.HasOne(x => x.Grammar)
                .WithMany(e => e.GrammarResults)
                .HasForeignKey(x => x.GrammarId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.User)
                .WithMany(u => u.GrammarResults)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
