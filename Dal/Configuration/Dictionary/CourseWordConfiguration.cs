using Domain.Entity.Content;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Dal.Configuration.Dictionary
{
    public class CourseWordConfiguration : IEntityTypeConfiguration<CourseWord>
    {
        public void Configure(EntityTypeBuilder<CourseWord> builder)
        {
            builder.ToTable("CourseWord", "dbo");
            builder.HasKey(e => e.Id);
            builder.Property(x => x.Id)
              .ValueGeneratedOnAdd()
              .HasColumnName("Id");

            builder.HasOne(cw => cw.Course)
                .WithMany(c => c.CourseWords)
                .HasForeignKey(cw => cw.CourseId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(cw => cw.Dictionary)
                .WithMany(c => c.CourseWords)
                .HasForeignKey(cw => cw.DictionaryId)
                .OnDelete(DeleteBehavior.Cascade);


        }
    }
}
