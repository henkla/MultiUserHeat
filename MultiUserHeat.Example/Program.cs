using System;
using System.Collections.Generic;

namespace MultiUserHeat.Example
{
    class Program
    {
        static void Main(string[] args)
        {
            var someCompetitors = GetSomeCompetitors();
            var race = new Race(RaceType.Default, someCompetitors);

            Console.WriteLine($"Nu startar ett race av typen {race.Type}!");
            race.StartRace();

            
            foreach (var heat in race.Heats)
            {
                Console.WriteLine($"Resultat heat {heat.Number}:");

                foreach (var result in heat.HeatResult)
                {
                    Console.WriteLine($"{result.Key} -- {result.Value.Name} [{result.Value.StartingNumber}]");
                }
            }

            Console.ReadKey();
        }

        private static List<Competitor> GetSomeCompetitors()
        {
            return new List<Competitor>
            {
                new Competitor
                {
                    Name = "Henrik Larsson",
                    StartingNumber = 1
                },
                new Competitor
                {
                    Name = "Rolf Lassgård",
                    StartingNumber = 2
                },
                new Competitor
                {
                    Name = "Somin Ells",
                    StartingNumber = 3
                },
                new Competitor
                {
                    Name = "Jens-Margot Antersson",
                    StartingNumber = 4,
                },
                new Competitor
                {
                    Name = "Kåre Påtat",
                    StartingNumber = 5
                },
            };
        }
    }
}
