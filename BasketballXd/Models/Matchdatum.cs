﻿using System;
using System.Collections.Generic;

namespace BasketballXd.Models;

public partial class Matchdatum
{
    public Guid Id { get; set; }

    public DateTime SubIn { get; set; }

    public DateTime SubOut { get; set; }

    public int Fga { get; set; }

    public int Fgm { get; set; }

    public int Foul { get; set; }

    public DateTime CreatedTime { get; set; }

    public DateTime UpdatedTime { get; set; }

    public Guid PlayerId { get; set; }

    public virtual Player Player { get; set; } = null!;
}
