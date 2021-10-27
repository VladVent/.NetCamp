using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace ConsoleApp1
{
    class Program
    {
        public static void Dump(Stack<Card> cards)
        {
            foreach (var card in cards)
            {
                Console.WriteLine(card);
            }
        }


        static void Main(string[] args)
        {
            var p1 = new Player { Name = "TempName" };
            var p2 = new Player { Name = "TempName2" };

            var session = new TableSessions();

            session.Join(p1);
            session.Join(p2);

            session.GetACard(p1);

            session.PlayerPoint(p1);

            session.FinishDobora(p2);

            Dump(p1.CardsInHands);

            // session.NextTurn();

            session.WinPoints(p1);
            Console.ReadKey();
        }
    }
}