using EFPractice.DatabaseAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFPractice.DatabaseAccess.Configurations;

public class LoanConfiguration : IEntityTypeConfiguration<Loan>
{
    public void Configure(EntityTypeBuilder<Loan> builder)
    {
        builder.HasKey(l => l.Id);

        builder.Property(l => l.LoanDate)
            .IsRequired();

        builder.Property(l => l.ReturnDate)
            .IsRequired(false);

        builder.Property(l => l.DueDate)
            .IsRequired(false);

        builder
            .HasOne(l => l.Book)
            .WithMany(b => b.Loans)
            .HasForeignKey(l => l.BookId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();

        builder
            .HasOne(l => l.Member)
            .WithMany(m => m.Loans)
            .HasForeignKey(l => l.MemberId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();

        builder.ToTable(t =>
        {
            t.HasCheckConstraint("CK_Loan_Dates",
                @"[LoanDate] IS NOT NULL AND 
                [DueDate] IS NOT NULL AND
                [LoanDate] <= [DueDate] AND
                [LoanDate] <= CAST(GETDATE() AS DATE) AND
                ([ReturnDate] IS NULL OR [ReturnDate] >= [LoanDate])");
        });
    }
}