using Domain.Entity.Content.Question;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Dal.Configuration
{
    public class TestRightAnswerConfiguration : IEntityTypeConfiguration<TestRightAnswer>
    {
        public void Configure(EntityTypeBuilder<TestRightAnswer> builder)
        {
            builder.ToTable("TestRightAnser", "dbo");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
               .ValueGeneratedOnAdd()
               .HasColumnName("Id");
            builder.Property(e => e.TimeStamp)
                .IsRowVersion()
                .IsConcurrencyToken();
            builder.Property(e => e.RightAnswer)
                .IsRequired()
                .HasColumnName("RightAnswer")
                .HasMaxLength(500);

            builder
                .HasOne(e => e.TestQuestion)
                .WithOne(e => e.RightAnswer)
                .HasForeignKey<TestRightAnswer>(e => e.TestQuestionId)
                .IsRequired()
                .HasConstraintName("FK_TestQuestionRigthAnswer_TestQuestionId")
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
