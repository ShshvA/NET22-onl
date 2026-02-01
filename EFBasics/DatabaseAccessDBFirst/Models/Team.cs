using System;
using System.Collections.Generic;

namespace DatabaseAccessDBFirst.Models;

public class Team
{
    public int Id { get; set; }

    public string TeamName { get; set; } = null!;

    public DateOnly? FoundingDate { get; set; }

    public int? CoachId { get; set; }

    public virtual Coach? Coach { get; set; }

    public virtual ICollection<Player> Players { get; set; } = new List<Player>();
}
