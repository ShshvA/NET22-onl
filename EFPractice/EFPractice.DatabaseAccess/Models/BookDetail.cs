using System.ComponentModel.DataAnnotations;

namespace EFPractice.DatabaseAccess.Models;

public class BookDetail
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string? Summary { get; set; } = null!;

    [Required]
    public int PageCount { get; set; }

    [Required]
    public string? Language { get; set; } = null!;

    [Required]
    public int Edition { get; set; }

    [Required]
    public int? BookId { get; set; }

    public virtual Book? Book { get; set; }
}