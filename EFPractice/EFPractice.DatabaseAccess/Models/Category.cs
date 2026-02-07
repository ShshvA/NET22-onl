using System.ComponentModel.DataAnnotations;

namespace EFPractice.DatabaseAccess.Models;

public class Category
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string? Name { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<BookCategory> BookCategories { get; set; } = [];
}