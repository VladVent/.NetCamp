using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace ConsoleApp1
{
    public class ConsoleMessagePrinter : IGameRuleMessage
    {
        public void CleanWin()
        {
            Console.WriteLine("GG EZ!!!!");
        }
        private static string NamesToSingleString(IEnumerable<Player> enumerable)
        {
            return string.Join(",", enumerable.Select(x => x.Name));
        }

        public void PlayerLoseMessage(IEnumerable<Player> enumerable)
        {
           
            foreach (var p in enumerable)
            {
                p.IsContiniue = true;
            }
            Console.WriteLine("Loosers:" + NamesToSingleString(enumerable));
        }

        public void PlayerWinMessage(IEnumerable<Player> allWinners)
        {
            foreach (var p in allWinners)
            {
                if (!p.IsContiniue)
                {
                Console.WriteLine("Winners:" + NamesToSingleString(allWinners));
                p.IsContiniue = false;
                }
                else
                {
                    p.IsContiniue = true;
                }
            }
        }

        public void PlayersDrawMessage(IEnumerable<Player> allWinners)

        {
            Console.WriteLine("PlayersDrawMessage players:" + NamesToSingleString(allWinners));
        }
    }
}