using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Extensions
{
    public static class DeskExtensions
    {
        public static void outputdesc(this Stack<Card> cards)
        {
            foreach (Card c in cards)
            {
                Console.WriteLine(c.numbers + c.oldestCard + " " + c.suit);
            }
        }
    }
}
