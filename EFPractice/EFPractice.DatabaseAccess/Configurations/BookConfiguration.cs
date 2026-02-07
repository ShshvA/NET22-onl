using EFPractice.DatabaseAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFPractice.DatabaseAccess.Configurations;

public class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.HasKey(b => b.Id);

        builder.Property(b => b.Title)
            .IsRequired();

        builder.Property(b => b.ISBN)
            .IsRequired();

        builder.Property(b => b.PublicationYear)
            .IsRequired(false);

        builder.Property(b => b.Price)
            .HasPrecision(10, 2)
            .IsRequired(false);

        builder.HasIndex(b => b.ISBN)
            .IsUnique();

        builder
            .HasOne(b => b.Author)
            .WithMany(a => a.Books)
            .HasForeignKey(b => b.AuthorId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();

        builder
            .HasOne(b => b.Publisher)
            .WithMany(p => p.Books)
            .HasForeignKey(b => b.PublisherId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired(false);

        builder.ToTable(t =>
        {
            t.HasCheckConstraint("CK_Book_Price",
                "[Price] IS NULL OR [Price] > 0");

            t.HasCheckConstraint("CK_Book_PublicationYear",
                @"[PublicationYear] IS NULL OR 
                ([PublicationYear] >= 1700 AND [PublicationYear] <= YEAR(GETDATE()))");
        });
    }
}
