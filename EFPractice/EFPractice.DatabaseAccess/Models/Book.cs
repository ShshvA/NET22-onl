using System.ComponentModel.DataAnnotations;

namespace EFPractice.DatabaseAccess.Models;

public class Book
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string? Title { get; set; } = null!;

    [Required]
    public string? ISBN { get; set; } = null!;

    public int? PublicationYear { get; set; }

    public decimal? Price { get; set; }

    [Required]
    public int? AuthorId { get; set; } = null!;

    public int? PublisherId { get; set; }

    public virtual Author? Author { get; set; }

    public virtual Publisher? Publisher { get; set; }

    public virtual ICollection<BookCategory> BookCategories { get; set; } = [];

    public virtual BookDetail? BookDetail { get; set; }

    public virtual ICollection<Loan> Loans { get; set; } = [];
}