using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    public class Player
    {
        public string Name { get; set; }
        public Stack<Card> CardsInHands = new Stack<Card>();
        public int SumPoint => CardsInHands.Sum(x => x.Power);

       public bool Continiue = false;
    }
}