using Domain.Entity.User.UserProfile;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dal.Configuration.UserProfile
{
    public class SociableConfiguration : IEntityTypeConfiguration<UserSociable>
    {
        public void Configure(EntityTypeBuilder<UserSociable> builder)
        {
            builder.ToTable("UserSociable", "dbo");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("Id");

            builder.Property(e => e.TimeStamp)
                .IsRowVersion()
                .IsConcurrencyToken();

            builder.Property(e => e.Sociable)
                .HasColumnName("Sociable")
                .IsRequired();

            builder.Property(e => e.Link)
                .HasDefaultValue("")
                .HasColumnName("Link")
                .HasMaxLength(300)
                .IsRequired();

            builder.Property(e => e.IconPath)
                .HasColumnName("Icon Path")
                .HasMaxLength(300)
                .IsRequired();

            builder.HasOne(e => e.User)
            .WithMany(e => e.UserSociables) 
            .HasForeignKey(e => e.UserId) 
            .OnDelete(DeleteBehavior.Cascade); 
        }
    }
}
