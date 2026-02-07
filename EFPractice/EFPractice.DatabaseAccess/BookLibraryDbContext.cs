using Microsoft.EntityFrameworkCore;
using EFPractice.DatabaseAccess.Configurations;
using EFPractice.DatabaseAccess.Models;

namespace EFPractice.DatabaseAccess;

public class BookLibraryDbContext : DbContext
{
    public BookLibraryDbContext(DbContextOptions options) : base(options)
    {
    }

    protected BookLibraryDbContext()
    {
        Database.EnsureCreated();
    }

    public virtual DbSet<Book> Books { get; set; }
    public virtual DbSet<Author> Authors { get; set; }
    public virtual DbSet<Category> Categories { get; set; }
    public virtual DbSet<Publisher> Publishers { get; set; }
    public virtual DbSet<Member> Members { get; set; }
    public virtual DbSet<Loan> Loans { get; set; }
    public virtual DbSet<BookDetail> BookDetails { get; set; }
    public virtual DbSet<AuthorBiography> AuthorBiographies { get; set; }
    public virtual DbSet<MemberContact> MemberContacts { get; set; }
    public virtual DbSet<BookCategory> BookCategories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new BookConfiguration());
        modelBuilder.ApplyConfiguration(new AuthorConfiguration());
        modelBuilder.ApplyConfiguration(new CategoryConfiguration());
        modelBuilder.ApplyConfiguration(new PublisherConfiguration());
        modelBuilder.ApplyConfiguration(new MemberConfiguration());
        modelBuilder.ApplyConfiguration(new LoanConfiguration());
        modelBuilder.ApplyConfiguration(new BookDetailConfiguration());
        modelBuilder.ApplyConfiguration(new AuthorBiographyConfiguration());
        modelBuilder.ApplyConfiguration(new MemberContactConfiguration());
        modelBuilder.ApplyConfiguration(new BookCategoryConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}
