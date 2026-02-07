using System.ComponentModel.DataAnnotations;

namespace EFPractice.DatabaseAccess.Models;

public class Publisher
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string? Name { get; set; } = null!;

    public string? Address { get; set; }

    public string? Website { get; set; }

    public virtual ICollection<Book> Books { get; set; } = [];
}