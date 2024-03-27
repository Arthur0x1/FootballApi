using System;
using System.Collections.Generic;

namespace FootballApi.Domains.Entities;

public partial class Position
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int DisplayOrder { get; set; }

    public virtual ICollection<Player> Players { get; set; } = new List<Player>();
}
