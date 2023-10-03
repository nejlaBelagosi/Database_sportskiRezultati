using System;
using System.Collections.Generic;

namespace sportskiRezultati.Models
{
    public partial class Country
    {
        public Country()
        {
            Leagues = new HashSet<League>();
            Teams = new HashSet<Team>();
        }

        public int CountryId { get; set; }
        public string CountryName { get; set; } = null!;

        public virtual ICollection<League> Leagues { get; set; }
        public virtual ICollection<Team> Teams { get; set; }
    }
}
