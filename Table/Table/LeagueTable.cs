using System;
using System.Collections.Generic;
using System.Text;

namespace Table
{
    class LeagueTable:Match
    {
        Match match = new Match();
        public int Wins { get; set; }
        public int Losses { get; set; }
        public int Draws { get; set; }
        public int Points { get; set; }
        public int GoalsFor { get; set; }
        public int GoalsAgainst { get; set; }


        public int getPlayed() 
        {
            return Wins + Losses + Draws;
            
        }

        public int getPoint() 
        {
            return Wins * 3 + Draws;
        }

        public int getGoalDifference() 
        {
            return GoalsFor - GoalsAgainst;
        }

        public void addwin() 
        {
            Wins ++;
            Points += 3;
            GoalsFor += HomeTeamGoal;
            GoalsAgainst += AwayTeamGoal;
        }
        public void AddDraw()
        {
            Draws++;
            Points++;
            GoalsFor += HomeTeamGoal;
            GoalsAgainst += AwayTeamGoal;
        }
        public void AddLoss()
        {
            Losses++;
            Points += 0;
            GoalsFor += AwayTeamGoal;
            GoalsAgainst += HomeTeamGoal;
        }
    }
}
