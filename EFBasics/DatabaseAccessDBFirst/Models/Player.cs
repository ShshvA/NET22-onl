using System;
using System.Collections.Generic;

namespace DatabaseAccessDBFirst.Models;

public class Player
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public int? Age { get; set; }

    public decimal? Salary { get; set; }

    public int? TeamId { get; set; }

    public virtual Team? Team { get; set; }
}
