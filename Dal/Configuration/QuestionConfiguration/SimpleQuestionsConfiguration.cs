﻿

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Entity.Content.Question;


namespace Dal.Configuration.Questions
{
    public class SimpleQuestionsConfiguration : IEntityTypeConfiguration<SimpleQuestion>
    {
        public void Configure(EntityTypeBuilder<SimpleQuestion> builder)
        {
            builder.ToTable("Simple_Question", "dbo");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd().HasColumnName("Id");
            builder.Property(e => e.TimeStamp).IsRowVersion().IsConcurrencyToken();
            builder.Property(e => e.QuestionText).IsRequired().HasColumnName("QuestionText").HasMaxLength(400);
            builder.Property(e => e.QType).IsRequired().HasColumnName("QuestionType");
            builder.Property(e => e.AType).IsRequired().HasColumnName("AnswerType");
        }
    }
}