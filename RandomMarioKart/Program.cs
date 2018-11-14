using System;
using System.Collections.Generic;
using System.Linq;

namespace RandomMarioKart
{
    class Program
    {
        static readonly Random random = new Random();

        static void Main(string[] args)
        {
            foreach (string nextGame in GetNextGame())
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine(nextGame);
                Console.ReadKey();
            }
        }

        private static IEnumerable<string> GetNextGame()
        {
            List<string> listOfGames = new List<string>
            {
                "Super Mario Kart",
                "Mario Kart 64",
                "Mario Kart: Double Dash!!",
                "Mario Kart 7",
                "Mario Kart 8",
                "Mario Kart 8 Deluxe",
            };

            List<string> playedGames = new List<string>();
            string lastGame = "";

            while (true)
            {
                int randomIndex = random.Next(0, listOfGames.Count);
                string chosenGame = listOfGames[randomIndex];
                if (lastGame != chosenGame)
                {
                    yield return chosenGame;
                    lastGame = chosenGame;
                    listOfGames.RemoveAt(randomIndex);
                    playedGames.Add(chosenGame);
                    if (playedGames.Count == 6)
                    {
                        listOfGames.AddRange(playedGames);
                        playedGames.Clear();
                    }
                }
            }
        }
    }
}
