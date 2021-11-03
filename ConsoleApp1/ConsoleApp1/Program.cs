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
                session.DealCard();
            while (session.DeckIsEmpty())
            {
                PlayerCardPrinter(players);
                foreach (var p in players)
                {
                    while (!p.IsContiniue)
                    {
                        Console.WriteLine($"{p.Name} Choise 0 if wanna take card, Choise 1 if wanna skip");
                        choise = Convert.ToInt32(Console.ReadLine());
                        switch (choise)
                        {
                            case 0:
                                session.PlayerChoiseCard(p);
                                PlayerCardPrinter(players);
                                session.CheckGameRules();
                                continue;
                            case 1:
                                p.IsContiniue = true;
                                break;
                        }
                    }
                }
                PlayerCardPrinter(players);
                session.CheckGameRules();
                Console.WriteLine("Choise 0 if wanna continue game, Choise 1 if wanna  end game");
                choise = Convert.ToInt32(Console.ReadLine());
                switch (choise)
                {
                    case 0:
                        session.DealCard();
                        Console.Clear();
                        foreach (var p in players)
                        {
                            p.IsContiniue = false;
                        }
                        continue;
                    case 1:
                        break;
                }
                break;
            }
            Console.WriteLine("See u next time");
            Console.ReadKey();
        }
    }
}