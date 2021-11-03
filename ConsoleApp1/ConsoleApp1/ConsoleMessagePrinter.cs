using System;
using System.Collections.Generic;
using System.Linq;

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
            Console.WriteLine("Loosers:" + NamesToSingleString(enumerable));
        }

        public void PlayerWinMessage(IEnumerable<Player> allWinners)
        {
            Console.WriteLine("Winners:" + NamesToSingleString(allWinners));
        }

        public void PlayersDrawMessage(IEnumerable<Player> allWinners)

        {
            Console.WriteLine("PlayersDrawMessage players:" + NamesToSingleString(allWinners));
        }
    }
}