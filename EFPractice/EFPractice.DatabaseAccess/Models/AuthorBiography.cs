using System.ComponentModel.DataAnnotations;

namespace EFPractice.DatabaseAccess.Models;

public class AuthorBiography
{
    [Key]
    public int Id { get; set; }

    public string? Education { get; set; }

    public string? Awards { get; set; }

    [Required]
    public string? BiographyText { get; set; } = null!;

    public int? AuthorId { get; set; }

    public virtual Author? Author { get; set; }
}