using Domain.Entity.Content.Lessons;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Dal.Configuration.Lessonsconfiguration
{
    public class TheoryConfiguration : IEntityTypeConfiguration<Theory>
    {
        public void Configure(EntityTypeBuilder<Theory> builder)
        {
            builder.ToTable("Theory", "dbo");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd().HasColumnName("Id");
            builder.Property(e => e.TimeStamp).IsRowVersion().IsConcurrencyToken();
            builder.Property(e => e.Title).IsRequired().HasColumnName("Title");
            builder.Property(e => e.Type).IsRequired().HasColumnName("Type");
            builder.Property(e => e.TextContent).HasColumnName("Text_content");
            builder.Property(e => e.ImagePath).HasColumnName("Image_path");
            builder.Property<string>("_serializedListContent").HasColumnName("ListContent").HasColumnType("text");
        }
    }
}
