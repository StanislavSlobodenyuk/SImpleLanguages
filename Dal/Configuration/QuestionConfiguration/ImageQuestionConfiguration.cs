
using Domain.Entity.Content.Question;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Dal.Configuration.QuestionConfiguration
{
    public class ImageQuestionConfiguration : IEntityTypeConfiguration<ImageQuestion>
    {
        public void Configure(EntityTypeBuilder<ImageQuestion> builder)
        {
            builder.ToTable("Image_Question", "dbo");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd().HasColumnName("Id");
            builder.Property(e => e.ImagePath).IsRequired().HasColumnName("Image_path");
            builder.Property(e => e.TimeStamp).IsRowVersion().IsConcurrencyToken();
            builder.Property(e => e.QuestionText).IsRequired().HasColumnName("QuestionText").HasMaxLength(400);
            builder.Property(e => e.QType).IsRequired().HasColumnName("QuestionType");
            builder.Property(e => e.AType).IsRequired().HasColumnName("AnswerType");
        }
    }
}
