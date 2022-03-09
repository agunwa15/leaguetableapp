using System;
using System.Collections.Generic;
using System.Linq;


namespace Table
{
    class Program
    {

        static List<Team> teams = getAllTeams();
        static void Main(string[] args)
        {

            Console.WriteLine("The Premier League Table 2021/2022");

            bool quit = false;

            while (quit == false)
            {
                int option = showMenu();
                if (option == 1)
                {
                    listTeams();
                }
                else if (option == 2)
                {
                    Match();
                }
                else if (option == 3)
                {
                    LeagueTable();

                }
                else if (option == 4)
                {
                    quit = true;
                }
            }
        }

        static int showMenu()
        {
            int ans = 0;
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("Enter 1 to view team list");
            Console.WriteLine("Enter 2 to enter match");
            Console.WriteLine("Enter 3 to view league table");
            Console.WriteLine("Enter 4 to quit \n");
            Console.Write("Enter your option: ");
            ans = Convert.ToInt32(Console.ReadLine());
            return ans;
        }

        static List<Team> getAllTeams()
        {

            List<Team> teams = new List<Team>
            {
           
            new Team{ Id= 1, Name = "Arsenal"},
            new Team{ Id= 2, Name = "Aston Villa"},
            new Team{ Id= 3, Name = "Brentford" },
            new Team{ Id= 4, Name = "Brigthon & Hove Albion"},
            new Team{ Id= 5, Name = "Burnley"},
            new Team{ Id= 6, Name = "chelsea" },
            new Team{ Id= 7, Name = "Crystal Palace" },
            new Team{ Id= 8, Name = "Everton" },
            new Team{ Id= 9, Name = "Leeds United" },
            new Team{ Id= 10, Name = "Leicester City" },
            new Team{ Id= 11, Name = "Liverpool" },
            new Team{ Id= 12, Name = "Manchester City" },
            new Team{ Id= 13, Name = "Manchester United" },
            new Team{ Id= 14, Name = "Newcastle United" },
            new Team{ Id= 15, Name = "Norwich City" },
            new Team{ Id= 16, Name = "Southampton" },
            new Team{ Id= 17, Name = "Tottenham Hotspur" },
            new Team{ Id= 18, Name = "Watford" },
            new Team{ Id= 19, Name = "Westham United" },
            new Team{ Id= 20, Name = "Wolverhampton Wanderers" },

            };
            return teams;
        }

        static void listTeams()
        {
            List<Team> teams = getAllTeams();

            Console.ForegroundColor = ConsoleColor.Yellow;
            foreach (var team in teams)
            {
                Console.WriteLine(team.Id.ToString()+" - "+team.Name);
            }
            Console.WriteLine("");
            Console.ResetColor();
        }

        static void Match() 
        {
            Team homeTeam = fetchTeam("Home");
      
            Team awayTeam = fetchTeam("Away");

            //Search the match list if this fixture already has been played and decline if true
            Match existingFixture = Matches.Where(x => x.HomeTeam == homeTeam.Id && x.AwayTeam == awayTeam.Id).FirstOrDefault();

            if (existingFixture == null)
            {
                MatchDetail(homeTeam, awayTeam);
            }
            else
            {
                Console.WriteLine("This fixture has already been entered");
            }

           

        }

        static void LeagueTable()
        {
           


            foreach (var team in teams)
            {
                Console.WriteLine(team.Id.ToString() + " - " + team.Name + "  Games palyed: " + team.gamesPlayed  + " Wins: " + team.wins + " Loss: " + team.Loss + " Draw: "+team.Draw + " Points: " + team.points);
                teams = teams.OrderBy(x => x.Id).ToList();
            }
            
        }


        static Team fetchTeamById(int teamID) 
        {
            Team team = teams.ToArray().Where(x => x.Id == teamID).FirstOrDefault();
            return team;
        }
        

        static Team fetchTeam(string teamType)
        {
            Team team = new Team();
            bool success = false;

            while (success == false)
            {
                Console.Write("Please enter "+teamType+" team: ");
                int teamID =Convert.ToInt32( Console.ReadLine());

                team = fetchTeamById(teamID);
                
                if (team != null)
                {
                    success = true;
                }
               
               
                

            }
            return team;
        }

        static Match MatchDetail(Team homeTeam,Team awayTeam)
        {
            Match match = new Match();
            match.HomeTeam = homeTeam.Id;
            match.AwayTeam = awayTeam.Id;
            Console.Write("Please enter goals for "+homeTeam.Name+": ");
            match.HomeTeamGoal = Convert.ToInt32(Console.ReadLine());
            Console.Write("Please enter goals for "+awayTeam.Name+": ");
            match.AwayTeamGoal = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(homeTeam.Name + " " + match.HomeTeamGoal + "-" + match.AwayTeamGoal + " " + awayTeam.Name+"\n");
            if (match.HomeTeamGoal > match.AwayTeamGoal)
            {
                Console.WriteLine(homeTeam.Name + " Wins."+"\n");
                homeTeam.points += 3;
                homeTeam.wins ++;
                awayTeam.Loss++;


            }
            else if (match.HomeTeamGoal < match.AwayTeamGoal)
            {
                Console.WriteLine(awayTeam.Name + " Wins." + "\n");
                awayTeam.points += 3;
                awayTeam.wins ++;
                homeTeam.Loss++;
            }
            else
            {
                Console.WriteLine("The match ends as a draw" + "\n");
                homeTeam.points += 1;
                awayTeam.points += 1;
                homeTeam.Draw++;
                awayTeam.Draw++;
            }

            homeTeam.gamesPlayed++;
            awayTeam.gamesPlayed++;
           
            Matches.Add(match);

            return match;
            
        }

        static List<Match> Matches = new List<Match>
        {


        };
        
    }
}
