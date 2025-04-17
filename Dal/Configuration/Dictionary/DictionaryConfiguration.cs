using Domain.Entity.Content.DictionaryContent;
using Domain.Entity.User.UserProfile;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Dal.Configuration.Dictionary
{
    internal class DictionaryConfiguration : IEntityTypeConfiguration<MyDictionary>
    {
        public void Configure(EntityTypeBuilder<MyDictionary> builder)
        {
            builder.ToTable("Dictionary", "dbo");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("Id");

            builder.Property(e => e.TimeStamp)
                .IsRowVersion()
                .IsConcurrencyToken();

            builder.Property(e => e.Word)
                .HasColumnName("Word")
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(e => e.Language)
                .HasColumnName("Language")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(e => e.LanguageLevel)
                .HasColumnName("LanguageLevel")
                .HasMaxLength(50)
                .IsRequired();

            builder
            .HasMany(d => d.CourseWords)
            .WithOne(cw => cw.Dictionary)
            .HasForeignKey(cw => cw.DictionaryId)
            .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasMany(d => d.UserWords)
                .WithOne(uw => uw.Dictionary)
                .HasForeignKey(uw => uw.DictionaryId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
