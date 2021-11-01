using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace ConsoleApp1
{
    public class Player
    {
       
        public string Name { get; set; }
        public Stack<Card> CardsInHands = new Stack<Card>();
        public int SumPoint;

        public int PointMark()
        {
            return SumPoint = CardsInHands.Sum(x => x.Power);
        }

    }
}