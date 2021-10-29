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
            
            var session = new TableSessions();


            while (session.DeckIsEmpty())
            {

                session.Join(p1);
                session.Join(p2);


                session.GetACard(p2);
                PName(p1);
            Dump(p1.CardsInHands);
            PPower(p1);
            PName(p2);
            Dump(p2.CardsInHands);
                PPower(p2);
                session.CheckRount();
            }
                session.WinPoints();

            Console.ReadKey();
        }
    }
}