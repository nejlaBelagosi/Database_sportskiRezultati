using System;
using System.Collections.Generic;

namespace sportskiRezultati.Models
{
    public partial class AwayTeam
    {
        public int AwayTeamId { get; set; }
        public int AwayTeam1 { get; set; }

        public virtual Team AwayTeam1Navigation { get; set; } = null!;
    }
}
