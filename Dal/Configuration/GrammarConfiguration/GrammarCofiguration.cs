
using Domain.Entity.Content.GrammarContent;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dal.Configuration.GrammarConfiguration
{
    public class GrammarConfiguration : IEntityTypeConfiguration<Grammar>
    {
        public void Configure(EntityTypeBuilder<Grammar> builder)
        {
            builder.ToTable("Grammar", "dbo");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("Id");

            builder.Property(e => e.TimeStamp)
                .IsRowVersion()
                .IsConcurrencyToken();

            builder.Property(e => e.Title)
                .IsRequired()
                .HasColumnName("Title")
                .HasMaxLength(255);

            builder.HasOne(e => e.Course)
                .WithMany(c => c.Grammars)  
                .HasForeignKey(e => e.CourseId)  
                .OnDelete(DeleteBehavior.Cascade); 
        }
    }
}
