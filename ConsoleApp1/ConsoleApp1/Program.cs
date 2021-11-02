using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace ConsoleApp1
{
    class Program
    {
        public static void Dump(Stack<Card> cards)
        {
            foreach (var c in cards)
            {
                Console.WriteLine($"{c.Name} {c.CardSuit} {c.Power}");
            }
        }
        public static void PName(Player players)
        {
            Console.WriteLine(players.Name);
        }

        public static void PPower(Player players)
        {
            Console.WriteLine(players.SumPoint);
        }

        static void Main(string[] args)
        {
            var p1 = new Player { Name = "TempName",};
            var p2 = new Player { Name = "TempName2" };
            var p3 = new Player { Name = "TempName3" };
            var session = new TableSessions();
            int choise;
            session.Join(p1);
                Console.WriteLine($"Hello {p1.Name}.");
                session.Join(p2);
                Console.WriteLine($"Hello {p2.Name}.");
                session.Join(p3);
                session.DealCard(p1);
            while (session.DeckIsEmpty())
            {
                PName(p1);
                Dump(p1.CardsInHands);
                PPower(p1);
                session.DealCard(p2);
                session.DealCard(p3);
                Console.WriteLine("Choise 0 if wanna take card, Choise 1 if wanna skip");
                choise = Convert.ToInt32(Console.ReadLine());
                switch (choise)
                {
                    case 0:
                        session.GetACard(p1);
                        continue;
                    case 1:
                        break;
                }
                session.GetACard(p2);


                PName(p1);
                Dump(p1.CardsInHands);
                PPower(p1);

               PName(p2);
              Dump(p2.CardsInHands);
               PPower(p2);

            PName(p3);
            Dump(p3.CardsInHands);
            PPower(p3);

                //session.CheckRound();
                Console.WriteLine("Choise 0 if wanna continue game, Choise 1 if wanna  end game");
                choise = Convert.ToInt32(Console.ReadLine());
                switch (choise)
                {
                    case 0:
                        session.DealCard(p1);
                        Console.Clear();
                        continue;
                    case 1:
                        break;
                }
                break;
            }
            Console.Clear();
            Console.ReadKey();
        }
    }
}