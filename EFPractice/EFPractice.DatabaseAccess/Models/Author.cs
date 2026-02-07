using System.ComponentModel.DataAnnotations;

namespace EFPractice.DatabaseAccess.Models;

public class Author
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string? FirstName { get; set; } = null!;

    [Required]
    public string? LastName { get; set; } = null!;

    public DateOnly? BirthDate { get; set; }

    public string? Country { get; set; }

    public virtual ICollection<Book> Books { get; set; } = [];

    public virtual AuthorBiography? AuthorBiography { get; set; }
}