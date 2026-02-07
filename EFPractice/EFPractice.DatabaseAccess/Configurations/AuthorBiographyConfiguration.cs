using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EFPractice.DatabaseAccess.Models;

namespace EFPractice.DatabaseAccess.Configurations;

public class AuthorBiographyConfiguration : IEntityTypeConfiguration<AuthorBiography>
{
    public void Configure(EntityTypeBuilder<AuthorBiography> builder)
    {
        builder.HasKey(ab => ab.Id);

        builder.Property(ab => ab.Education)
            .IsRequired(false);

        builder.Property(ab => ab.Awards)
            .IsRequired(false);

        builder.Property(ab => ab.BiographyText)
            .IsRequired();

        builder
            .HasOne(ab => ab.Author)
            .WithOne(a => a.AuthorBiography)
            .HasForeignKey<AuthorBiography>(ab => ab.AuthorId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}