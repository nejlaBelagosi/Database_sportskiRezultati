using System;
using System.Collections.Generic;

namespace sportskiRezultati.Models
{
    public partial class Match
    {
        public Match()
        {
            Teams = new HashSet<Team>();
        }

        public int MatchId { get; set; }
        public string Venue { get; set; } = null!;
        public DateTime MatchDate { get; set; }
        public TimeSpan MatchTime { get; set; }
        public string Results { get; set; } = null!;
        public int? HomeTeamGoal { get; set; }
        public int? AwayTeamGoal { get; set; }

        public virtual ICollection<Team> Teams { get; set; }
    }
}
