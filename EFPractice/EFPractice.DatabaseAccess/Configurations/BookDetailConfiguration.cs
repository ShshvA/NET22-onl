using EFPractice.DatabaseAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFPractice.DatabaseAccess.Configurations;

public class BookDetailConfiguration : IEntityTypeConfiguration<BookDetail>
{
    public void Configure(EntityTypeBuilder<BookDetail> builder)
    {
        builder.HasKey(bd => bd.Id);

        builder.Property(bd => bd.Summary)
            .IsRequired();

        builder.Property(bd => bd.PageCount)
            .IsRequired();

        builder.Property(bd => bd.Language)
            .IsRequired();

        builder.Property(bd => bd.Edition)
            .IsRequired();

        builder
            .HasOne(bd => bd.Book)
            .WithOne(b => b.BookDetail)
            .HasForeignKey<BookDetail>(bd => bd.BookId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.ToTable(t =>
        {
            t.HasCheckConstraint("CK_BookDetail_PageCount",
                "[PageCount] > 0");

            t.HasCheckConstraint("CK_BookDetail_Edition",
                "[Edition] > 0");
        });
    }
}
