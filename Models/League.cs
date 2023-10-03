using System;
using System.Collections.Generic;

namespace sportskiRezultati.Models
{
    public partial class League
    {
        public League()
        {
            Teams = new HashSet<Team>();
        }

        public int LeagueId { get; set; }
        public string LeagueName { get; set; } = null!;
        public int NumberOfTeams { get; set; }
        public int CountryId { get; set; }

        public virtual Country Country { get; set; } = null!;
        public virtual ICollection<Team> Teams { get; set; }
    }
}
