using System;
using System.Collections.Generic;

namespace FootballApi.Domains.Entities;

public partial class Player
{
    public int Id { get; set; }

    public int ShirtNo { get; set; }

    public string Name { get; set; } = null!;

    public int PositionId { get; set; }

    public int Appearances { get; set; }

    public int Goals { get; set; }

    public double PositionX { get; set; }

    public double PositionY { get; set; }

    public virtual Position Position { get; set; } = null!;
}
