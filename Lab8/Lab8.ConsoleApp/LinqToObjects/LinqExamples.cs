using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8.ConsoleApp.LinqToObjects
{
    public class LinqExamples
    {
        public void LinqExample1()
        {
            string[] videoGames = { "Fallout 3", "Rome 2: Total War", "Counter-Strike", "Crisys 3", "Far Cry 4" };
            IEnumerable<string> subset = from g in videoGames
                                         where g.Contains("3")
                                         select g;

            Console.WriteLine("**** Displaying games in subset:");

            foreach (var game in subset)
            {
                Console.WriteLine(game);
            }

            Console.WriteLine("**** End Display games");
            Console.WriteLine();
        }

        public void LinqExample2()
        {
            string[] videoGames = { "Fallout 3", "Rome 2: Total War", "Counter-Strike", "Crisys 3", "Far Cry 4" }; ;
            IEnumerable<string> subset = from g in videoGames
                                         where g.Length > 8 && g.Contains(" ")
                                         select g;

            Console.WriteLine("**** Displaying games in subset:");

            foreach (var game in subset)
            {
                Console.WriteLine(game);
            }

            Console.WriteLine("**** End Display games");
            Console.WriteLine();
        }

        public void LinqExample3()
        {
            string[] videoGames = { "Fallout 3", "Rome 2: Total War", "Counter-Strike", "Crisys 3", "Far Cry 4" }; ;
            IEnumerable<string> subset = from g in videoGames
                                         where g.Length > 8 && g.Contains(" ")
                                         select g;

            Console.WriteLine("**** Displaying games in subset:");

            subset.ToList().ForEach(item => Console.WriteLine(item));

            Console.WriteLine("**** End Display games");
            Console.WriteLine();
        }

        public IEnumerable<Game> GetGamesWithSpace()
        {
            var gameList = new List<Game>();
            gameList.Add(new Game { Name = "Fallout 3", Price = 40 });
            gameList.Add(new Game { Name = "Rome 2: Total War", Price = 45 });
            gameList.Add(new Game { Name = "Counter-Strike", Price = 50 });
            gameList.Add(new Game { Name = "Crysis 3", Price = 60 });
            gameList.Add(new Game { Name = "Far Cry 4", Price = 30 });
            gameList.Add(new Game { Name = "South Park - The Stick of Truth", Price = 35 });

            IEnumerable<Game> subset = from g in gameList
                                       where g.Price > 30 && g.Name.Contains(" ")
                                       orderby g.Name descending
                                       select g;

            return subset;
        }
    }

    public class Game
    {
        public string Name { get; set; }

        public double Price { get; set; }
    }

}
