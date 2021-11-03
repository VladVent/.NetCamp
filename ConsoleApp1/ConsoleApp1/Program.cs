using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Serialization;

namespace ConsoleApp1
{
    class Program
    {
        public static void PlayerCardPrinter(List<Player> players)
        {
            foreach (var p in players)
            {
                Console.WriteLine($"{p.Name}");
                foreach (var c in p.CardsInHands)
                {
                    Console.WriteLine($"{c.Name} {c.CardSuit} {c.Power}");

                }
                Console.WriteLine($"Ur Points: {p.SumPoint}");
            }
        }

        public static void PlayerNamePrinter(List<Player> players)
        {
            foreach (var p in players)
            {
                Console.WriteLine(p.Name);
            }
        }

        public static void GreetingPlayers(List<Player> players)
        {
            foreach (var p in players)
            {
                Console.WriteLine($"Hello {p.Name}.");
            }

        }


        static void Main(string[] args)
        {
            List<Player> players = new List<Player>();

            players.Add(new Player() { Name = "Vent" });
            players.Add(new Player() { Name = "Zest" });

            var session = new TableSessions();
            int choise;
            session.Join(players);
            GreetingPlayers(players);
            while (session.DeckIsEmpty())
            {
                session.DealCard();
                PlayerCardPrinter(players);
                foreach (var p in players)
                {
                    Console.WriteLine($"{p.Name} Choise 0 if wanna take card, Choise 1 if wanna skip");
                    choise = Convert.ToInt32(Console.ReadLine());
                    session.PlayerChoiseCard(choise);
                    break;
                }
                PlayerCardPrinter(players);
                break;
            }
            Console.ReadKey();
        }
    }
}