using System;
using System.Collections.Generic;
using System.Text;

namespace Table
{
    class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int gamesPlayed { get; set; }
        public int points { get; set; }
        public int wins { get; set; }
        public int Loss { get; set; }
        public int Draw { get; set; }


        Team(int Id, String Name)
        {
            this.Id = Id;
            this.Name = Name;
            this.gamesPlayed = 0;
            this.points = 0;
            this.wins = 0;
            this.Draw = 0;
            this.Loss = 0;

        }
        public Team()
        {
            this.Id = Id;
            this.Name = Name;
        }
    }
}
