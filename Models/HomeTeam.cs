using System;
using System.Collections.Generic;

namespace sportskiRezultati.Models
{
    public partial class HomeTeam
    {
        public int HomeTeamId { get; set; }
        public int HomeTeam1 { get; set; }

        public virtual Team HomeTeam1Navigation { get; set; } = null!;
    }
}
