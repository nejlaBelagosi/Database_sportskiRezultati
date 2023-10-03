using System;
using System.Collections.Generic;

namespace sportskiRezultati.Models
{
    public partial class Player
    {
        public int PlayerId { get; set; }
        public int JerseyNumber { get; set; }
        public string PlayerName { get; set; } = null!;
        public string PlayerSurname { get; set; } = null!;
        public DateTime BirthDate { get; set; }
        public int Age { get; set; }
        public string Position { get; set; } = null!;
        public int TeamId { get; set; }

        public virtual Team Team { get; set; } = null!;
    }
}
