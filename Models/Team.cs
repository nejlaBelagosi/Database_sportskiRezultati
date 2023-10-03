using System;
using System.Collections.Generic;

namespace sportskiRezultati.Models
{
    public partial class Team
    {
        public Team()
        {
            AwayTeams = new HashSet<AwayTeam>();
            HomeTeams = new HashSet<HomeTeam>();
            Players = new HashSet<Player>();
        }

        public int TeamId { get; set; }
        public string TeamName { get; set; } = null!;
        public int NumberOfPlayers { get; set; }
        public int CountryId { get; set; }
        public int LeagueId { get; set; }
        public int MatchId { get; set; }

        public virtual Country Country { get; set; } = null!;
        public virtual League League { get; set; } = null!;
        public virtual Match Match { get; set; } = null!;
        public virtual ICollection<AwayTeam> AwayTeams { get; set; }
        public virtual ICollection<HomeTeam> HomeTeams { get; set; }
        public virtual ICollection<Player> Players { get; set; }
    }
}
