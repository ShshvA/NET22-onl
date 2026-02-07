using System.ComponentModel.DataAnnotations;

namespace EFPractice.DatabaseAccess.Models;

public class BookCategory
{
    public int BookId { get; set; }

    public int CategoryId { get; set; }

    [Required]
    public DateOnly? AddedDate { get; set; } = null!;

    public Book? Book { get; set; }

    public Category? Category { get; set; }
}