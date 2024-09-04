using Domain.Entity.Content.Image;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entity.Content.Question;

namespace Dal.Configuration
{
    public class AudioQuestionConfiguration : IEntityTypeConfiguration<AudioQuestion>
    {
        public void Configure(EntityTypeBuilder<AudioQuestion> builder)
        {
            builder.ToTable(" AudioQuestion", "dbo");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
               .ValueGeneratedOnAdd()
               .HasColumnName("Id");
            builder.Property(e => e.TimeStamp)
                .IsRowVersion()
                .IsConcurrencyToken();
            builder.Property(e => e.AudioUrl)
                .HasMaxLength(300)
                .IsRequired();
            builder.Property(e => e.RightAnswer)
                .HasMaxLength(300)
                .IsRequired();
            builder.Property(e => e.Type)
                .IsRequired();
        }
    }
}
