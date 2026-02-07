using EFPractice.DatabaseAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFPractice.DatabaseAccess.Configurations;

public class MemberConfiguration : IEntityTypeConfiguration<Member>
{
    public void Configure(EntityTypeBuilder<Member> builder)
    {
        builder.HasKey(m => m.Id);

        builder.Property(m => m.FirstName)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(m => m.LastName)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(a => a.Email)
            .IsRequired();

        builder.Property(a => a.BirthDate)
            .IsRequired(false);

        builder.ToTable(t =>
        {
            t.HasCheckConstraint("CK_Member_FirstName",
                "[FirstName] IS NOT NULL AND LEN(TRIM([FirstName])) > 0");

            t.HasCheckConstraint("CK_Member_LastName",
                "[LastName] IS NOT NULL AND LEN(TRIM([LastName])) > 0");

            t.HasCheckConstraint("CK_Member_BirthDate",
                "[BirthDate] IS NULL OR [BirthDate] <= CAST(GETDATE() AS DATE)");
        });
    }
}
