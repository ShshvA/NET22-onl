using EFPractice.DatabaseAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFPractice.DatabaseAccess.Configurations;

public class AuthorConfiguration : IEntityTypeConfiguration<Author>
{
    public void Configure(EntityTypeBuilder<Author> builder)
    {
        builder.HasKey(a => a.Id);

        builder.Property(a => a.FirstName)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(a => a.LastName)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(a => a.BirthDate)
            .IsRequired(false);

        builder.Property(a => a.Country)
            .IsRequired(false);

        builder.ToTable(t =>
        {
            t.HasCheckConstraint("CK_Author_FirstName",
                "[FirstName] IS NOT NULL AND LEN(TRIM([FirstName])) > 0");

            t.HasCheckConstraint("CK_Author_LastName",
                "[LastName] IS NOT NULL AND LEN(TRIM([LastName])) > 0");

            t.HasCheckConstraint("CK_Author_BirthDate",
                "[BirthDate] IS NULL OR [BirthDate] <= CAST(GETDATE() AS DATE)");
        });
    }
}
