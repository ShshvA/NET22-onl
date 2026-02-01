using System;
using System.Collections.Generic;

namespace DatabaseAccessDBFirst.Models;

public class Coach
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public int? Age { get; set; }

    public virtual ICollection<Team> Teams { get; set; } = new List<Team>();
}
