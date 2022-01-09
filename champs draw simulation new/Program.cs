using System;
using System.Collections.Generic;

namespace champs_darw_simulation
{
    class Team
    {
        public string name;
        public string group;
        public bool is_first;
        public string country;
        public List<Team> valid_opponents = new List<Team>();

        public Team(string n, string gr, bool first, string con)
        {
            name = n;
            group = gr.ToLower();
            is_first = first;
            country = con.ToLower();
        }

    }
    class Program
    {
        static bool is_only_team(List<Team> teams, Team team_name)
        {
            bool only_team = false;
            foreach (Team t in teams)
            {
                if (t.valid_opponents.Count == 1 && t.valid_opponents.Contains(team_name))
                {
                    only_team = true;
                }
            }
            return only_team;
        }
        static void Main(string[] args)
        {

            List<Team> drawn_runners_up = new List<Team>();
            List<Team> drawn_winners = new List<Team>();
            Team man_city = new Team("Man City", "a", true, "England");
            Team psg = new Team("PSG", "a", false, "France");
            Team liverpool = new Team("Liverpool", "b", true, "England");
            Team atm = new Team("Atletico Madrid", "b", false, "Spain");
            Team ajax = new Team("Ajax", "c", true, "Netherlands");
            Team sporting = new Team("Sporting CF", "c", false, "Portugal");
            Team rm = new Team("Real Madrid", "d", true, "Spain");
            Team inter = new Team("INTER MILAN ", "d", false, "Italy");
            Team bayern = new Team("Bayern", "e", true, "Germany");
            Team benfica = new Team("Benfica", "e", false, "Portugal");
            Team man_utd = new Team("Man United", "f", true, "England");
            Team vill = new Team("Villareal", "f", false, "Spain");
            Team lille = new Team("Lille", "g", true, "France");
            Team salzburg = new Team("RB Salzburg ", "g", false, "Austria");
            Team juve = new Team("Juventus", "h", true, "Italy");
            Team chelsea = new Team("Chelsea", "h", false, "England");

            List<Team> qualified_teams = new List<Team> { man_city, psg, liverpool, atm, ajax, sporting, rm, inter, bayern, benfica, man_utd, vill, lille, salzburg, juve, chelsea };

            List<Team> group_winners = new List<Team>();
            List<Team> runners_up = new List<Team>();

            foreach (Team t in qualified_teams)
            {
                if (t.is_first == true)
                {
                    group_winners.Add(t);
                }
                else
                {
                    runners_up.Add(t);
                }
            }

            foreach (Team t in qualified_teams)
            {
                foreach (Team tt in qualified_teams)
                {
                    if (t.is_first != tt.is_first && t.group != tt.group && t.country != tt.country)
                    {
                        t.valid_opponents.Add(tt);
                    }
                }
            }
            Console.WriteLine("GLORY'S CHAMPIONS LEAGUE RO16 DRAW");
            Console.WriteLine("\n");

            Console.WriteLine("Press Enter to view the qualified teams");
            string useless5 = Console.ReadLine();
            Console.WriteLine("\n");
            int count = 0;
            foreach (Team t in qualified_teams)
            {
                Console.WriteLine("Team {0} is {1} and has the following possible opponents", count + 1, t.name);
                count++;
                foreach (Team tt in t.valid_opponents)
                {
                    Console.WriteLine(tt.name);
                }
                Console.WriteLine("\n");

                if (count <= 15)
                {
                    Console.WriteLine("Press enter to view next team that qualified for the RO16");
                    string useless = Console.ReadLine();
                }

            }


            Console.WriteLine("Press enter to begin the draw");
            string useless4 = Console.ReadLine();
            Console.WriteLine("\n");

            for (int i = 0; i < 8; i++)
            {
                Console.WriteLine("Press enter to see the runner up team chosen");
                string useless3 = Console.ReadLine();

                Random r = new Random();
                int runner = r.Next(0, runners_up.Count);
                Team runner_team = runners_up[runner];

                Console.WriteLine("The runner up team chosen is {0}", runner_team.name);
                Console.WriteLine("\n");
                runners_up.Remove(runner_team);

                int winner = r.Next(0, runner_team.valid_opponents.Count);
                Team winner_team = runner_team.valid_opponents[winner];

                bool is_last_runner = false;
                bool is_last_winner = false;

                foreach (Team t in runners_up)
                {
                    if (t.valid_opponents.Count == 1 && t.valid_opponents.Contains(winner_team))
                    {
                        is_last_winner = true;
                        runner_team.valid_opponents.Remove(winner_team);
                    }
                }

                Console.WriteLine("The possible opponents for {0} are as follows", runner_team.name);
                foreach (Team t in runner_team.valid_opponents)
                {
                    Console.WriteLine(t.name);

                }
                if (is_last_winner)
                {
                    winner = r.Next(0, runner_team.valid_opponents.Count);
                    winner_team = runner_team.valid_opponents[winner];

                }
                foreach (Team t in group_winners)
                {
                    if (t.valid_opponents.Count == 1 && t.valid_opponents.Contains(runner_team) && t != winner_team && drawn_winners.Contains(t) == false)
                    {
                        is_last_runner = true;
                        winner_team = t;
                    }
                }

                foreach (Team t in runners_up)
                {
                    t.valid_opponents.Remove(winner_team);

                }

                foreach (Team t in group_winners)
                {
                    if (t.valid_opponents.Contains(runner_team))
                    {

                        t.valid_opponents.Remove(runner_team);
                    }
                }


                drawn_runners_up.Add(runner_team);
                drawn_winners.Add(winner_team);
                Console.WriteLine("PRESS ENTER TO SEE WHO {0} is drawn with ", runner_team.name);
                string useless2 = Console.ReadLine();

                Console.WriteLine("{0}  is drawn with {1}", runner_team.name, winner_team.name);
                Console.WriteLine(".");
                Console.WriteLine("."); Console.WriteLine("."); Console.WriteLine(".");
            }
            Console.WriteLine("Press enter to see the final draw");
            string usel = Console.ReadLine();

            Console.WriteLine("THE FINAL DRAWS ARE AS FOLLOWS: ");


            for (int a = 0; a < 8; a++)
            {
                Console.WriteLine("{0}   vs   {1}", drawn_runners_up[a].name, drawn_winners[a].name);

            }

        }

    }


}



