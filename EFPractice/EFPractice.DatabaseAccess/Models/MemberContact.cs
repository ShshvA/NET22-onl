using System.ComponentModel.DataAnnotations;

namespace EFPractice.DatabaseAccess.Models;

public class MemberContact
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string? Phone { get; set; } = null!;

    [Required]
    public string? Address { get; set; } = null!;

    [Required]
    public string? City { get; set; } = null!;

    public int? MemberId { get; set; }

    public virtual Member? Member { get; set; }
}