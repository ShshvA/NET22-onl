using System.ComponentModel.DataAnnotations;

namespace EFPractice.DatabaseAccess.Models;

public class Member
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string? FirstName { get; set; } = null!;

    [Required]
    public string? LastName { get; set; }

    [Required]
    public string? Email { get; set; } = null!;

    public DateOnly? BirthDate { get; set; } = null!;

    public virtual ICollection<Loan> Loans { get; set; } = [];

    public virtual MemberContact? MemberContact { get; set; }
}