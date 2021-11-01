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

                session.Join(p1);
                Console.WriteLine($"Hello {p1.Name}.");
                session.Join(p2);
                Console.WriteLine($"Hello {p2.Name}.");
            while (session.DeckIsEmpty())
            {
                session.DealCard(p1);
                session.DealCard(p2);

                session.GetACard(p2); //Не знімати карти. Вийде нескінченний цикл гри самої з собою

                PName(p1);
            Dump(p1.CardsInHands);
            PPower(p1);
            PName(p2);
            Dump(p2.CardsInHands);
            PPower(p2);
            session.CheckRound();
            }
            Console.ReadKey();
        }
    }
}