﻿
using Domain.Entity.Content.Image;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dal.Configuration
{
    public class MyImageConfiguration : IEntityTypeConfiguration<MyImage>
    {
        public void Configure(EntityTypeBuilder<MyImage> builder)
        {
            builder.ToTable("MyImage", "dbo");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
               .ValueGeneratedOnAdd()
               .HasColumnName("Id");
            builder.Property(e => e.TimeStamp)
                .IsRowVersion()
                .IsConcurrencyToken();
            builder.Property(e => e.ImagePath)
                .HasMaxLength(200)
                .IsRequired();
        }
    }
}