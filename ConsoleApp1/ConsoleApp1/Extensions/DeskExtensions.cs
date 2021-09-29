using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Extensions
{
   public static class DeskExtensions
    {
        public static void outputdesc(this List<Card> cards)
        {
            cards.ForEach(x => Console.WriteLine(x.numbers));
        }
    }
}
