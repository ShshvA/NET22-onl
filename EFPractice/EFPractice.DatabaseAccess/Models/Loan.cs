using System.ComponentModel.DataAnnotations;

namespace EFPractice.DatabaseAccess.Models;

public class Loan
{
    [Key]
    public int Id { get; set; }

    [Required]
    public DateOnly? LoanDate { get; set; } = null!;

    public DateOnly? ReturnDate { get; set; }

    [Required]
    public DateOnly? DueDate { get; set; }

    public int? BookId { get; set; }

    public int? MemberId { get; set; }

    public virtual Book? Book { get; set; }

    public virtual Member? Member { get; set; }
}