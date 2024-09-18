
using Domain.Entity.Content.Lessons;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dal.Configuration
{
    public class LectureBlockConfiguration : IEntityTypeConfiguration<LectureBlock>
    {
        public void Configure(EntityTypeBuilder<LectureBlock> builder)
        {
            builder.ToTable("Lecture", "dbo");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
               .ValueGeneratedOnAdd()
               .HasColumnName("Id");

            builder.Property(e => e.TimeStamp)
                .IsRowVersion()
                .IsConcurrencyToken();

            builder.Property(e => e.Title)
                .IsRequired()
                .HasColumnName("Title")
                .HasMaxLength(400);

            builder.Property(e => e.Content)
              .IsRequired()
              .HasColumnName("Content");
        }
    }
}
