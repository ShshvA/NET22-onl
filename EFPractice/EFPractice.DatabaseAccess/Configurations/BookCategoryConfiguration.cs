using EFPractice.DatabaseAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFPractice.DatabaseAccess.Configurations;

public class BookCategoryConfiguration : IEntityTypeConfiguration<BookCategory>
{
    public void Configure(EntityTypeBuilder<BookCategory> builder)
    {
        builder.HasKey(bc => new { bc.BookId, bc.CategoryId });

        builder.Property(bc => bc.AddedDate)
            .IsRequired();

        builder.HasOne(bc => bc.Book)
               .WithMany(b => b.BookCategories)
               .HasForeignKey(bc => bc.BookId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(bc => bc.Category)
               .WithMany(c => c.BookCategories)
               .HasForeignKey(bc => bc.CategoryId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}